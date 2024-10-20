using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Ef;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("product elave olundu");
        }

        public IResult Delete(int id)
        {
            Product deleteProduct = null;
            Product resultProduct = _productDal.Get(p => p.IsDeleted == false && p.Id == id);
            if (resultProduct != null)
                deleteProduct = resultProduct;
            deleteProduct.IsDeleted = true;
            _productDal.Delete(deleteProduct);
            return new SuccessResult();
        }

       

        public IDataResult<List<Product>> GetAllProducts()
        {
            var products = _productDal.GetAll(p => p.IsDeleted == false).ToList();
            if (products.Count > 0)
                return new SuccessDataResult<List<Product>>(products);
            else return new ErrorDataResult<List<Product>>("xeta bash verdi");
        }
    }
}
