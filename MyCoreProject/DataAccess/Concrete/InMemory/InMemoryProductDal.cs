using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=10 },
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitsInStock=12,UnitPrice=500 },
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitsInStock=5,UnitPrice=1000 },
            new Product{ProductId=4,CategoryId=2,ProductName="airPod",UnitsInStock=7,UnitPrice=1500 },
            new Product{ProductId=5,CategoryId=2,ProductName="Klavye",UnitsInStock=4,UnitPrice=25 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product producttodelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(producttodelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int Id)
        {
          return  _products.Where(p=>p.CategoryId==Id).ToList();
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product producttoUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            producttoUpdate.ProductName = product.ProductName;
            producttoUpdate.CategoryId = product.CategoryId;
            producttoUpdate.UnitsInStock = product.UnitsInStock;
            producttoUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
