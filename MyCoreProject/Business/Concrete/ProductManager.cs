using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                //magic string
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintainanceTime);
            }
            return new SuccessDataResult<List<Product>>( _productdal.GetAll(),true,Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetByCategory(int id)
        {
            return new SuccessDataResult<List<Product>> (_productdal.GetAll(p=>p.CategoryId==id));//id ile ürünün kategori id si eşitse listele
        }

        public IDataResult<Product> GetById(int productId)
        {
           return new SuccessDataResult<Product>( _productdal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productdal.GetAll(p => p.UnitPrice >=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productdal.GetProductDetail());
        }
    }
}
