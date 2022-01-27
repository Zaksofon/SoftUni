using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos.InputModels;
using ProductShop.Models;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
            //var productsJsonAsString = File.ReadAllText("../../../Datasets/products.json");
            //var categoriesJsonAsString = File.ReadAllText("../../../Datasets/categories.json");
            //var categoriesAndProductsAsString = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersJsonAsString));
            //Console.WriteLine(ImportProducts(context, productsJsonAsString));
            //Console.WriteLine(ImportCategories(context, categoriesJsonAsString));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesAndProductsAsString));
            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));

        }

        //PRODUCT SHOP
        //01. Import Users 
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users =
                JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            var mapperConfig = new MapperConfiguration(config => { config.AddProfile<ProductShopProfile>(); });

            IMapper mapper = new Mapper(mapperConfig);
                
            IEnumerable<User> mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> products =
                JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            var mapperConfig = new MapperConfiguration(config => { config.AddProfile<ProductShopProfile>(); });

            IMapper mapper = new Mapper(mapperConfig);

            IEnumerable<Product> mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        // 03. Import Categories 
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoriesInputDto> categories =
                JsonConvert.DeserializeObject<IEnumerable<CategoriesInputDto>>(inputJson);

            var mapperConfig = new MapperConfiguration(config => { config.AddProfile<ProductShopProfile>(); });

            IMapper mapper = new Mapper(mapperConfig);

            IEnumerable<Category> mappedCategories = mapper.Map<IEnumerable<Category>>(categories)
                .Where(x => x.Name != null)
                .ToList();

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        // 04. Import Categories and Products 
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoriesProductsInputDto> categoriesProducts =
                JsonConvert.DeserializeObject<IEnumerable<CategoriesProductsInputDto>>(inputJson);

            var mapperConfiguration = new MapperConfiguration(config => { config.AddProfile<ProductShopProfile>(); });

            IMapper mapper = new Mapper(mapperConfiguration);

            IEnumerable<CategoryProduct> mappedCategoryProducts =
                mapper.Map<IEnumerable<CategoryProduct>>(categoriesProducts);

            context.CategoryProducts.AddRange(mappedCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count()}";
        }

        // 05. Export Products In Range 
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .OrderBy(x => x.price)
                .ToList();

            var productsToJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsToJson.Trim();

        }

        // 06. Export Sold Products 
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(user => new
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    soldProducts = user.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(b => new
                        {
                            name = b.Name,
                            price = b.Price,
                            buyerFirstName = b.Buyer.FirstName,
                            buyerLastName = b.Buyer.LastName
                        }).ToList(),
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        // 07. Export Categories By Products Count 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(cp => new
                {
                    category = cp.Name,
                    productsCount = cp.CategoryProducts.Count,
                    averagePrice = cp.CategoryProducts.Average(p => p.Product.Price)
                        .ToString("F2"),
                    totalRevenue = cp.CategoryProducts.Sum(p => p.Product.Price)
                        .ToString("F2")
                })
                .OrderByDescending(cp => cp.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return result;
        }

        // 08. Export Users and Products 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(b => b.BuyerId.HasValue))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                        {
                            count = u.ProductsSold.Count(b => b.BuyerId.HasValue),
                            products = u.ProductsSold.Where(b => b.BuyerId.HasValue)
                                .Select(s => new
                                {
                                    name = s.Name,
                                    price = s.Price
                                })
                        }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var result = JsonConvert.SerializeObject(resultObject, Formatting.Indented, jsonSerializerSettings);

            return result;
        }
    }
}