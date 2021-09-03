using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data transformation Object
             ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            Product silgi = new Product
            {
                ProductId = 8,
                ProductName = "silgi",
                CategoryId = 1,
                UnitsInStock = 50,
                UnitPrice = 5
            };
            var result = productManager.GetAll();
            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/ " + result.Message);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            //productManager.Add(silgi);
            
        }
    }
}
