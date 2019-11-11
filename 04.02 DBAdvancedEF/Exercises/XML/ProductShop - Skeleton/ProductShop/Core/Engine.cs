using AutoMapper;
using ProductShop.Core.Methods.Import;
using ProductShop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop.Core
{
    public class Engine
    {
        public void Run()
        {
        //    //PRODUCTSHOP CONFIG APP
            Mapper.Initialize(config => config.AddProfile(new ProductShopProfile()));

        //    if (File.Exists(Importing()))
        //    {
        //        //read the xml
        //        var readFile = File.ReadAllText(Importing());

        //        using (ProductShopContext context = new ProductShopContext())
        //        {
        //            xmlImports import = new xmlImports();
        //            Console.WriteLine(import.ImportUsers(context, readFile));
        //        }
        //    }
        }

        public string Importing()
        {
            //pc
            string pcWork = "borko";
            string pcHome = "RR";

            //toor path to datasets
            string Path =
                $@"C:\Users\{pcHome}\Dropbox\SoftUni\04.02 DBAdvancedEF\Exercises\XML\ProductShop - Skeleton\ProductShop\Datasets\";

            //datasets names
            string categories = "categories.xml";
            string categoriesProducts = "categories-products.xml";
            string products = "products.xml";
            string users = "users.xml";

            //concat paths and strings
            var concatPath = Path + categoriesProducts;

            return concatPath;
        }

    }
}
