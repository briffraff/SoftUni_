using AutoMapper;
using ProductShop.Core;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    using Data;
    public class StartUp
    {
        private const string SuccessMessage = "Successfully imported";

        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();

            //toDelete->
            var importing = engine.Importing();

            if (File.Exists(importing))
            {
                //read the xml
                var readFile = File.ReadAllText(importing);

                using (ProductShopContext context = new ProductShopContext())
                {
                    //Console.WriteLine(ImportCategoryProducts(context, readFile));
                    Console.WriteLine(GetSoldProducts(context));
                }
            }
        }

        public static string SerializeObject<T>(T values, string rootName, bool omitXmlDeclaration = false,
            bool indentXml = true)
        {
            string xml = string.Empty;


            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var settings = new XmlWriterSettings()
            {
                Indent = indentXml,
                OmitXmlDeclaration = omitXmlDeclaration
            };

            XmlSerializerNamespaces @namespace = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, values, @namespace);
                xml = stream.ToString();
            }

            return xml;
        }


        public static string GetSoldProducts(ProductShopContext context)
        {
            //var usersWithOneItemAtLeast = context.Users
            //    .Where(u => u.ProductsSold.Count > 0)
            //    .OrderBy(u=>u.LastName)
            //    .ThenBy(u=>u.FirstName)
            //    .Take(5)
            //    .ProjectTo<UsersWithSoldProductsDTO>()
            //    .ToList();

            var usersWithOneItemAtLeast = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UsersWithSoldProductsDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold
                         .Select(ps => new SoldProductDTO
                         {
                             Name = ps.Name,
                             Price = ps.Price
                         })
                         .ToList()
                })
                .ToList();

            var xml = SerializeObject(usersWithOneItemAtLeast, "Users", false, true);
            return xml;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductDTO()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.LastName != null ? $"{x.Buyer.FirstName} {x.Buyer.LastName}" : null
                })
                .Take(10)
                .ToList();

            //var productsInRange = context.Products
            //    //.Include(x=>x.Buyer)
            //    .Where(x => x.Price >= 500 && x.Price <= 1000)
            //    .OrderBy(x => x.Price)
            //    .Take(10)
            //    .ProjectTo<ProductDTO>()
            //    .ToList();

            var xml = SerializeObject(productsInRange, "Product", false);
            return xml;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportCategoryProductDTO[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDTO = (ImportCategoryProductDTO[])xmlSerializer
                .Deserialize(new StringReader(inputXml));

            var cps = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDTO)
            {
                var product = context.Products.Find(categoryProductDto.ProductId);
                var category = context.Categories.Find(categoryProductDto.CategoryId);

                if (product == null || category == null)
                {
                    continue;
                }

                var categoryProduct = new CategoryProduct
                {
                    CategoryId = category.Id,
                    ProductId = product.Id
                };

                //var cp = Mapper.Map<CategoryProduct>(categoryProduct);
                cps.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(cps);
            context.SaveChanges();

            return $"{SuccessMessage} {cps.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDTO[]), new XmlRootAttribute("Categories"));

            var categoriesDTO = (ImportCategoriesDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDTO in categoriesDTO)
            {
                if (categoryDTO.Name == null)
                {
                    continue;
                }

                var category = Mapper.Map<Category>(categoryDTO);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"{SuccessMessage} {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));

            var productsDTO = (ImportProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDTO in productsDTO)
            {
                var product = Mapper.Map<Product>(productDTO);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"{SuccessMessage} {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            ////Equal to bottom part ,but not working fine
            //XDocument doc = XDocument.Load(new StringReader(inputXml));

            //var usersFromXml = doc.Root
            //    .Elements()
            //    .ToList();

            //var users = new List<User>();

            //usersFromXml.ForEach(x=>
            //{
            //    var userDTO = Mapper.Map<ImportUserDTO>(usersFromXml);
            //    var user = Mapper.Map<User>(userDTO);
            //    users.Add(user);
            //});

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportUserDTO[]), new XmlRootAttribute("Users"));

            var usersDTO = (ImportUserDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDTO)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"{SuccessMessage} {users.Count}";
        }
    }
}