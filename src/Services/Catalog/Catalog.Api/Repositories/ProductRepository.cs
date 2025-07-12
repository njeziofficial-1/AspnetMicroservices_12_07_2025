
namespace Catalog.Api.Repositories;

public class ProductRepository(ICatalogContext context) : IProductRepository
{
    public async Task CreateProductAsync(Product product)
    {
        await context.Products
            .InsertOneAsync(product);
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        var filter = Builders<Product>.Filter
            .Eq(p => p.Id, id);

        var deleteResult = await context.Products.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<Product?> GetProductByIdAsync(string id)
    {
        return await context.Products
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await context.Products
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
    {
        var filter = Builders<Product>.Filter
            .ElemMatch(p => p.Category, category);
        return await context.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        var filter = Builders<Product>.Filter
            .ElemMatch(p => p.Name, name);

        return await context.Products.Find(filter)
            .ToListAsync();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updatedResult = context.Products
            .ReplaceOneAsync(filter: p => p.Id == product.Id,replacement: product);
        return updatedResult.IsCompletedSuccessfully && updatedResult.Result.ModifiedCount > 0;
    }
}
