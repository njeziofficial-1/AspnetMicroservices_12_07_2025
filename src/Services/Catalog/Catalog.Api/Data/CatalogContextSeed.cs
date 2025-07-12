namespace Catalog.Api.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        bool existProduct = productCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productCollection.InsertManyAsync(GetPreconfiguredProducts());
        }
    }
    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return
        [
            // Smart Phones
            new Product { Name = "iPhone X", Category = "Smart Phone", Summary = "iPhone X", Description = "iPhone X", ImageFile = "product-1.png", Price = 1000 },
        new Product { Name = "Samsung Galaxy S21", Category = "Smart Phone", Summary = "Samsung Galaxy S21", Description = "Samsung Galaxy S21", ImageFile = "product-2.png", Price = 950 },
        new Product { Name = "Google Pixel 6", Category = "Smart Phone", Summary = "Pixel 6", Description = "Pixel 6", ImageFile = "product-3.png", Price = 880 },
        new Product { Name = "OnePlus 9", Category = "Smart Phone", Summary = "OnePlus 9", Description = "OnePlus 9", ImageFile = "product-4.png", Price = 890 },
        new Product { Name = "Huawei P50", Category = "Smart Phone", Summary = "Huawei P50", Description = "Huawei P50", ImageFile = "product-5.png", Price = 860 },
        new Product { Name = "Sony Xperia 5", Category = "Smart Phone", Summary = "Sony Xperia 5", Description = "Sony Xperia 5", ImageFile = "product-6.png", Price = 870 },
        new Product { Name = "Motorola Edge", Category = "Smart Phone", Summary = "Motorola Edge", Description = "Motorola Edge", ImageFile = "product-7.png", Price = 780 },
        new Product { Name = "Xiaomi Mi 11", Category = "Smart Phone", Summary = "Xiaomi Mi 11", Description = "Xiaomi Mi 11", ImageFile = "product-8.png", Price = 830 },
        new Product { Name = "Realme GT", Category = "Smart Phone", Summary = "Realme GT", Description = "Realme GT", ImageFile = "product-9.png", Price = 760 },
        new Product { Name = "Oppo Find X3", Category = "Smart Phone", Summary = "Oppo Find X3", Description = "Oppo Find X3", ImageFile = "product-10.png", Price = 820 },

        // Laptops
        new Product { Name = "MacBook Pro 14", Category = "Laptop", Summary = "Apple laptop", Description = "MacBook Pro M1", ImageFile = "product-11.png", Price = 2200 },
        new Product { Name = "Dell XPS 13", Category = "Laptop", Summary = "Dell Ultrabook", Description = "Dell XPS 13", ImageFile = "product-12.png", Price = 1500 },
        new Product { Name = "HP Spectre x360", Category = "Laptop", Summary = "Convertible laptop", Description = "HP Spectre x360", ImageFile = "product-13.png", Price = 1400 },
        new Product { Name = "Lenovo ThinkPad X1", Category = "Laptop", Summary = "Business laptop", Description = "ThinkPad X1 Carbon", ImageFile = "product-14.png", Price = 1600 },
        new Product { Name = "Asus ROG Zephyrus", Category = "Laptop", Summary = "Gaming laptop", Description = "Asus ROG Series", ImageFile = "product-15.png", Price = 2000 },
        new Product { Name = "Microsoft Surface Laptop 5", Category = "Laptop", Summary = "Sleek and fast", Description = "Surface Laptop 5", ImageFile = "product-16.png", Price = 1350 },
        new Product { Name = "Acer Swift 3", Category = "Laptop", Summary = "Affordable and powerful", Description = "Acer Swift 3", ImageFile = "product-17.png", Price = 1000 },
        new Product { Name = "LG Gram 17", Category = "Laptop", Summary = "Lightweight laptop", Description = "LG Gram", ImageFile = "product-18.png", Price = 1450 },
        new Product { Name = "Razer Blade 15", Category = "Laptop", Summary = "Gaming powerhouse", Description = "Razer Blade 15", ImageFile = "product-19.png", Price = 2100 },
        new Product { Name = "Samsung Galaxy Book Pro", Category = "Laptop", Summary = "Ultra-thin laptop", Description = "Galaxy Book Pro", ImageFile = "product-20.png", Price = 1300 },

        // Headphones
        new Product { Name = "Sony WH-1000XM4", Category = "Headphones", Summary = "Noise Cancelling", Description = "Over-ear ANC headphones", ImageFile = "product-21.png", Price = 350 },
        new Product { Name = "Bose QuietComfort 45", Category = "Headphones", Summary = "Bose ANC", Description = "Comfortable and quiet", ImageFile = "product-22.png", Price = 330 },
        new Product { Name = "AirPods Max", Category = "Headphones", Summary = "Apple over-ear", Description = "High fidelity Apple", ImageFile = "product-23.png", Price = 550 },
        new Product { Name = "Beats Studio3", Category = "Headphones", Summary = "Stylish sound", Description = "Beats by Dre", ImageFile = "product-24.png", Price = 300 },
        new Product { Name = "Sennheiser Momentum 4", Category = "Headphones", Summary = "Premium sound", Description = "German precision audio", ImageFile = "product-25.png", Price = 400 },
        new Product { Name = "Jabra Elite 85h", Category = "Headphones", Summary = "Smart ANC", Description = "Long battery life", ImageFile = "product-26.png", Price = 280 },
        new Product { Name = "Anker Soundcore Q45", Category = "Headphones", Summary = "Budget ANC", Description = "Affordable quality", ImageFile = "product-27.png", Price = 150 },
        new Product { Name = "Marshall Monitor II", Category = "Headphones", Summary = "Classic design", Description = "Rock-inspired audio", ImageFile = "product-28.png", Price = 320 },
        new Product { Name = "AKG N700NC", Category = "Headphones", Summary = "Balanced sound", Description = "AKG tuning", ImageFile = "product-29.png", Price = 260 },
        new Product { Name = "Shure AONIC 50", Category = "Headphones", Summary = "Studio sound", Description = "Professional grade", ImageFile = "product-30.png", Price = 370 },

        // Smart Watches
        new Product { Name = "Apple Watch Series 9", Category = "Smart Watch", Summary = "Latest Apple Watch", Description = "Fitness & smart features", ImageFile = "product-31.png", Price = 500 },
        new Product { Name = "Samsung Galaxy Watch 6", Category = "Smart Watch", Summary = "Samsung wearable", Description = "Health-focused smartwatch", ImageFile = "product-32.png", Price = 450 },
        new Product { Name = "Garmin Fenix 7", Category = "Smart Watch", Summary = "Outdoor GPS watch", Description = "Adventure-ready", ImageFile = "product-33.png", Price = 700 },
        new Product { Name = "Fitbit Sense 2", Category = "Smart Watch", Summary = "Health tracking", Description = "Stress & heart health", ImageFile = "product-34.png", Price = 300 },
        new Product { Name = "Amazfit GTR 4", Category = "Smart Watch", Summary = "Affordable tracking", Description = "Sleek and functional", ImageFile = "product-35.png", Price = 200 },
        new Product { Name = "TicWatch Pro 5", Category = "Smart Watch", Summary = "Wear OS powered", Description = "Hybrid display", ImageFile = "product-36.png", Price = 350 },
        new Product { Name = "Huawei Watch GT 3", Category = "Smart Watch", Summary = "Stylish fitness", Description = "Great battery life", ImageFile = "product-37.png", Price = 270 },
        new Product { Name = "Mobvoi TicWatch E3", Category = "Smart Watch", Summary = "Budget Wear OS", Description = "Smartwatch features", ImageFile = "product-38.png", Price = 180 },
        new Product { Name = "Fossil Gen 6", Category = "Smart Watch", Summary = "Classic design", Description = "Stylish smartwatch", ImageFile = "product-39.png", Price = 290 },
        new Product { Name = "Withings ScanWatch", Category = "Smart Watch", Summary = "Medical hybrid", Description = "ECG & sleep monitoring", ImageFile = "product-40.png", Price = 320 },

        // Tablets
        new Product { Name = "iPad Pro 12.9", Category = "Tablet", Summary = "Apple power tablet", Description = "M2 chip, large screen", ImageFile = "product-41.png", Price = 1300 },
        new Product { Name = "Samsung Galaxy Tab S9", Category = "Tablet", Summary = "Android flagship", Description = "AMOLED screen", ImageFile = "product-42.png", Price = 1200 },
        new Product { Name = "Microsoft Surface Pro 9", Category = "Tablet", Summary = "2-in-1 tablet PC", Description = "Laptop replacement", ImageFile = "product-43.png", Price = 1400 },
        new Product { Name = "Lenovo Tab P12 Pro", Category = "Tablet", Summary = "Productivity tablet", Description = "Stylus included", ImageFile = "product-44.png", Price = 900 },
        new Product { Name = "Amazon Fire HD 10", Category = "Tablet", Summary = "Affordable media", Description = "Amazon ecosystem", ImageFile = "product-45.png", Price = 150 },
        new Product { Name = "Xiaomi Pad 6", Category = "Tablet", Summary = "Entertainment tablet", Description = "Good for reading & games", ImageFile = "product-46.png", Price = 500 },
        new Product { Name = "Huawei MatePad Pro", Category = "Tablet", Summary = "Elegant productivity", Description = "Sleek and fast", ImageFile = "product-47.png", Price = 850 },
        new Product { Name = "Realme Pad X", Category = "Tablet", Summary = "Entry-level tablet", Description = "Light and capable", ImageFile = "product-48.png", Price = 300 },
        new Product { Name = "TCL Tab 10", Category = "Tablet", Summary = "Value for money", Description = "Budget Android tablet", ImageFile = "product-49.png", Price = 180 },
        new Product { Name = "Asus ROG Flow Z13", Category = "Tablet", Summary = "Gaming tablet", Description = "Powerhouse with GPU", ImageFile = "product-50.png", Price = 1600 }
        ];
    }

}
