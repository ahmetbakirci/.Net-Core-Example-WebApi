using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDataAccess _productDataAccess;

        public ProductManager(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }
        public Product Add(Product product) {
            return _productDataAccess.Create(product);
        }
        public Product Update(string id,Product product){
           return _productDataAccess.Update(id,product);
        }
        public void Delete(string id)
        {
            _productDataAccess.Delete(x => x.Id == id);
        }
        public Product GetById(string id) {
            
            return _productDataAccess.Get(x => x.Id == id);
        }
        public List<Product> GetAll()
        {
            return _productDataAccess.GetList().ToList();
        }

        public List<Image> GetImagesById(string id)
        {
            var product = _productDataAccess.Get(x=>x.Id == id);
            return product.ProductImages.ToList();
        }
        public Product AddImage(string productId, Image image)
        {
            var product = _productDataAccess.Get(x => x.Id == productId);
            product.ProductImages.Add(image);
            Update(productId,product);
            return product;
        }
    }
}
