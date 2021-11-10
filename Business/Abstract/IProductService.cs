using Entities;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        public Product Add(Product product);
        public Product Update(string id,Product product);
        public void Delete(string id);
        public Product GetById(string id);
        public List<Product> GetAll();
        public Product AddImage(string productId,Image image);
        public List<Image> GetImagesById(string id);
    }
}