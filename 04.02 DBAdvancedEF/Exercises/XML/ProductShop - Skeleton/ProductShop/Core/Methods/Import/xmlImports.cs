using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProductShop.Core.Methods.Import
{
    public class xmlImports
    {
        private const string SuccessMessage = "Successfully imported ";

        public string ImportUsers(ProductShopContext context, string inputXml)
        {
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

        public string ImportProducts(ProductShopContext context, string inputXml)
        {
            return $"{SuccessMessage} {"Count"}";
        }

        public string ImportCategories(ProductShopContext context, string inputXml)
        {
            return $"{SuccessMessage} {"Count"}";
        }

        public  string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            return $"{SuccessMessage} {"Count"}";
        }


    }
}
