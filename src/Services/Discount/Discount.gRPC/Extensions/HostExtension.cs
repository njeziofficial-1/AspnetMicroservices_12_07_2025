namespace Discount.gRPC.Extensions;

public static class HostExtension
{
    public static IHost MigrateDatabase<T>(this IHost host, int? retry = 0) where T : class
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<T>>();
        try
        {
            logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(T).Name);
            using var connection = new NpgsqlConnection(
                services.GetRequiredService<IConfiguration>().GetValue<string>("DatabaseSettings:ConnectionString"));
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "DROP TABLE IF EXISTS Coupon";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Coupon (
                    Id SERIAL PRIMARY KEY,
                    ProductName VARCHAR(100) NOT NULL,
                    Description TEXT,
                    Amount INT NOT NULL
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
    INSERT INTO Coupon (ProductName, Description, Amount) 
    VALUES 
        ('IPhone X', 'IPhone Discount', 150),
        ('Samsung 10', 'Samsung Discount', 100),
        ('Google Pixel 7', 'Pixel Discount', 120),
        ('OnePlus 11', 'OnePlus Discount', 110),
        ('Sony Xperia 5', 'Sony Discount', 130),
        ('Xiaomi Mi 11', 'Xiaomi Discount', 90),
        ('Motorola Edge', 'Motorola Discount', 80),
        ('Nokia G20', 'Nokia Discount', 70),
        ('Huawei P30', 'Huawei Discount', 105),
        ('Realme 9', 'Realme Discount', 95),
        ('Asus ROG Phone 5', 'Asus Discount', 160),
        ('LG Velvet', 'LG Discount', 85),
        ('HTC U12+', 'HTC Discount', 75),
        ('ZTE Axon 30', 'ZTE Discount', 100),
        ('Honor 50', 'Honor Discount', 115),
        ('Vivo X60', 'Vivo Discount', 90),
        ('Oppo Reno 6', 'Oppo Discount', 98),
        ('Infinix Zero 8', 'Infinix Discount', 65),
        ('Tecno Camon 17', 'Tecno Discount', 60),
        ('Lenovo Legion Duel', 'Lenovo Discount', 140);";
            command.ExecuteNonQuery();


            logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(T).Name);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(T).Name);
            if (retry < 50)
            {
                retry++;
                Thread.Sleep(2000);
                MigrateDatabase<T>(host, retry);
            }
        }
        return host;
    }
}
