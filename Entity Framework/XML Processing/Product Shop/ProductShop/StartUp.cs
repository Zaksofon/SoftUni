using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Datasets.Dtos.ImportDto;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string userInputXmlAsString = File.ReadAllText("../../../Datasets/users.xml");
            string productsInputXmlAsString = File.ReadAllText("../../../Datasets/products.xml");

            Console.WriteLine(ImportUsers(context, userInputXmlAsString));
            Console.WriteLine(ImportProducts(context, productsInputXmlAsString));
        }
        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersInputDto[]), xmlRoot);

            using (StringReader stringReader = new StringReader(inputXml))
            {
                UsersInputDto[] dtos = (UsersInputDto[])xmlSerializer.Deserialize(stringReader);

                ICollection<User> users = new HashSet<User>();

                foreach (var dtoUser in dtos)
                {
                    User user = new User()
                    {
                        FirstName = dtoUser.FirstName,
                        LastName = dtoUser.LastName,
                        Age = dtoUser.Age
                    };

                    users.Add(user);
                }

                context.Users.AddRange(users);
                context.SaveChanges();

                return $"Successfully imported {users.Count}";
            }
        }

        // 02. Import Products 
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductsInputDto[]), xmlRoot);

            using (StringReader stringReader = new StringReader(inputXml))
            {
                ProductsInputDto[] dtos = (ProductsInputDto[])xmlSerializer.Deserialize(stringReader);

                ICollection<Product> products = new HashSet<Product>();

                foreach (var dtoProduct in dtos)
                {
                    Product product = new Product()
                    {
                        Name = dtoProduct.Name,
                        Price = Convert.ToDecimal(dtoProduct.Price),
                        SellerId = dtoProduct.SellerId,
                        BuyerId = dtoProduct.BuyerId
                    };

                    products.Add(product);
                }

                context.Products.AddRange(products);
                context.SaveChanges();

                return $"Successfully imported {products.Count}";
            }
        }
    }
}