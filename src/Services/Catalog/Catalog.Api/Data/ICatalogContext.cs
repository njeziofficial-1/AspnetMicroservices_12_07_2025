using MongoDB.Driver;

namespace Catalog.Api.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
    //IMongoCollection<Entities.Category> Categories { get; }
    //IMongoCollection<Entities.Brand> Brands { get; }
    //Task<bool> IsDatabaseConnectedAsync();
    //Task<bool> CreateDatabaseAsync();
    //Task<bool> CreateCollectionsAsync();
    //Task<bool> SeedDataAsync();
}
