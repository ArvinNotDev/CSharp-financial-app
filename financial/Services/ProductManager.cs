using financial.JsonConverters;
using financial.Models;
using financial.Transactions;
using System.Text.Json;
using File = System.IO.File;

namespace financial.Services
{
    internal class ProductManager
    {
        private const string FilePath = "products.json";

        private static Dictionary<string, List<Product>> productsByUser = LoadProducts();

        public static Dictionary<string, List<Product>> LoadProducts()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                options.Converters.Add(new DateOnlyJsonConverter());

                return JsonSerializer.Deserialize<Dictionary<string, List<Product>>>(json, options)
                       ?? new Dictionary<string, List<Product>>();
            }

            return new Dictionary<string, List<Product>>();
        }

        public static bool SaveProducts()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new DateOnlyJsonConverter());

            string json = JsonSerializer.Serialize(productsByUser, options);
            File.WriteAllText(FilePath, json);
            return true;
        }

        public static (bool, string) AddProduct(string accountId, string name, string description, decimal price, TransactionType transactionType)
        {
            var product = new Product(name, description, price, transactionType);

            if (!productsByUser.ContainsKey(accountId))
                productsByUser[accountId] = new List<Product>();

            productsByUser[accountId].Add(product);
            return (SaveProducts(), "Product successfully added");
        }

        public static Product? GetProductById(string productId)
        {
            return productsByUser
                .SelectMany(kv => kv.Value)
                .FirstOrDefault(p => p.id == productId);
        }

        public static bool DeleteProduct(string productId)
        {
            foreach (var userProducts in productsByUser)
            {
                var product = userProducts.Value.FirstOrDefault(p => p.id == productId);
                if (product != null)
                {
                    userProducts.Value.Remove(product);
                    SaveProducts();
                    return true;
                }
            }
            return false;
        }

        public static bool UpdateProduct(string productId, string name, string description, decimal price, TransactionType transactionType)
        {
            var product = GetProductById(productId);
            if (product == null)
                return false;

            product.name = name;
            product.description = description;
            product.price = price;
            product.transactionType = transactionType;
            product.LastModifiedDate = DateTime.UtcNow;

            return SaveProducts();
        }

        public static List<Product> GetProductsByUser(string accountId)
        {
            return productsByUser.ContainsKey(accountId)
                ? productsByUser[accountId]
                : new List<Product>();
        }

        public static void PrintProductsForUser(string accountId)
        {
            if (productsByUser.TryGetValue(accountId, out var products))
            {
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.name} - {p.price} ({p.transactionType})");
                }
            }
            else
            {
                Console.WriteLine("No products found for this user.");
            }
        }
    }
}
