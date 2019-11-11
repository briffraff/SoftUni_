using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            string pcWork = "borko";
            string pcHome = "RR";

            string Path = $@"C:\Users\{pcHome}\Dropbox\SoftUni\04.02 DBAdvancedEF\Exercises\JSON\Product Shop - Skeleton\ProductShop\Datasets\";

            string usersJson = "users.json";
            string productJson = "products.json";
            string categoriesProductsJson = "categories-products.json";
            string categories = "categories.json";

            //var usersJs = File.ReadAllText(Path + categoriesProductsJson);
            //var result = ImportCategoryProducts(context, usersJs);
            //Console.WriteLine(result);

            Console.WriteLine(GetCategoriesByProductsCount(context));

        }


        //PRODUCTSHOP
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,

                    ProductsCount = c.CategoryProducts.Count(),

                    AveragePrice = c.CategoryProducts
                        .Select(p => p.Product.Price)
                        .Average()
                        .ToString("0.00"),

                    TotalRevenue = c.CategoryProducts
                        //.Where(p => p.Product.Buyer != null)
                        .Select(p => p.Product.Price)
                        .Sum()
                        .ToString("0.00")
                })
                .ToArray();

            CamelCasePropertyNamesContractResolver cccr = new CamelCasePropertyNamesContractResolver();

            var jsSettings = new JsonSerializerSettings()
            {
                ContractResolver = cccr,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonCategories = JsonConvert.SerializeObject(categories, jsSettings);

            return jsonCategories;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Count(ps => ps.Buyer != null),
                        Products = x.ProductsSold
                            .Where(ps => ps.Buyer != null)
                            .Select(ps => new
                            {
                                Name = ps.Name,
                                Price = ps.Price
                            })
                            .ToArray()
                    }
                })
                .ToArray();

            var result = new
            {
                UsersCount = usersWithProducts.Length,
                Users = usersWithProducts
            };

            //DefaultContractResolver cr = new DefaultContractResolver()
            //{
            //    NamingStrategy = new CamelCaseNamingStrategy()
            //};

            CamelCasePropertyNamesContractResolver cccr = new CamelCasePropertyNamesContractResolver();

            var jsSettings = new JsonSerializerSettings()
            {
                ContractResolver = cccr,
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonUsersWithProducts = JsonConvert.SerializeObject(
                result,
                Formatting.Indented,
                jsSettings);

            return jsonUsersWithProducts;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                //.Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        //.Where(ps => ps.Buyer != null)
                        .Select(ps => new
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                            buyerFirstName = ps.Buyer.FirstName,
                            buyerLastName = ps.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            //creating the new naming convention strategy
            CamelCasePropertyNamesContractResolver contractResolver = new CamelCasePropertyNamesContractResolver();

            //give that strategy to a jsonSerializerSettings
            var jsSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            //Serialize
            var jsonUsersSerialized = JsonConvert.SerializeObject(users, jsSettings);

            return jsonUsersSerialized;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            var jsonConverted = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return jsonConverted;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {

            var validCategoryIds = context
                .Categories
                .Select(c => c.Id)
                .ToHashSet();

            var validProductId = context
                .Products
                .Select(p => p.Id)
                .ToHashSet();

            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            var validEntities = new List<CategoryProduct>();

            foreach (var categoryProduct in categoryProducts)
            {
                bool isValid = validCategoryIds.Contains(categoryProduct.CategoryId) &&
                               validProductId.Contains(categoryProduct.ProductId);

                if (isValid)
                {
                    validEntities.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(validEntities);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null && c.Name.Length >= 3 && c.Name.Length <= 15)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";

        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => p.Name != null && p.Name.Length >= 3)
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}