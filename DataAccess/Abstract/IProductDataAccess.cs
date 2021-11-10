using Core.DataAccess;
using Entities;

namespace DataAccess.Abstract
{
    public interface IProductDataAccess : IEntityRepository<Product>
    {
    }
}
