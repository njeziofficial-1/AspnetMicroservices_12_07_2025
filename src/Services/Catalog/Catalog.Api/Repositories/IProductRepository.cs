namespace Catalog.Api.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(string id);
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    Task CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(string id);
}
