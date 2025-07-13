using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger) : ControllerBase
{
    // This controller will handle requests related to product catalog.
    // It will use the IProductRepository to interact with the product data.
    // The methods will be implemented in the next steps.

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        var products = await productRepository.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct(string id)
    {
        var product = await productRepository.GetProductByIdAsync(id);
        if (product == null)
        {
            logger.LogError($"Product with id: {id}, not found.");
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("[action]/{category}", Name = "GetProductByCategory")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductByCategory(string category)
    {
        var products = await productRepository.GetProductsByCategoryAsync(category);
        if (products == null || !products.Any())
        {
            logger.LogError($"No products found for category: {category}.");
            return NotFound();
        }
        return Ok(products);
    }

    [HttpGet("[action]/{name}", Name = "GetProductByName")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductByName(string name)
    {
        var products = await productRepository.GetProductsByNameAsync(name);
        if (products == null || !products.Any())
        {
            logger.LogError($"No products found for name: {name}.");
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            logger.LogError("Product object sent from client is null.");
            return BadRequest("Product object is null");
        }
        await productRepository.CreateProductAsync(product);
        return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            logger.LogError("Product object sent from client is null.");
            return BadRequest("Product object is null");
        }
        var existingProduct = await productRepository.GetProductByIdAsync(product.Id);
        if (existingProduct == null)
        {
            logger.LogError($"Product with id: {product.Id}, not found.");
            return NotFound();
        }
        var updated = await productRepository.UpdateProductAsync(product);
        if (!updated)
        {
            logger.LogError($"Error updating product with id: {product.Id}.");
            return BadRequest("Error updating product");
        }
        return NoContent();
    }
}
