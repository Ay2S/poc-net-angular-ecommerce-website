using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedDataAsync(StoreContext store, ILoggerFactory loggerFactory)
        {
            // Seed ProductBrands
            try
            {
                // Seed ProductBrands
                if (!store.ProductBrands.Any())
                {
                    string productBrandsData = File.ReadAllText("../Infrastructure/Data/SeedData/productbrands.json");
                    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
                    foreach (var productBrand in productBrands) store.ProductBrands.Add(productBrand);
                    await store.SaveChangesAsync();
                    // Entity.AsNoTracking().Update
                    // context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    // store.Entry(productBrand).State = EntityState.Detached;
                }

                // Seed ProductTypes
                if (!store.ProductTypes.Any())
                {
                    string productTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/producttypes.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
                    foreach (var productType in productTypes) store.ProductTypes.Add(productType);
                    await store.SaveChangesAsync();
                }

                // Seed Products
                if (!store.Products.Any())
                {
                    string productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var product in products) store.Products.Add(product);
                    await store.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "An error occured while seeding data for products brands!");
            }
        }
    }
}