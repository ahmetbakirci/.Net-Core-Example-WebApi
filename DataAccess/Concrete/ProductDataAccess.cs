using Core.DataAccess.DbSettings;
using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.Repository;
using Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Concrete
{
    public class ProductDataAccess : MongoRepositoryBase<Product>, IProductDataAccess
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Product> _collection;

        public ProductDataAccess(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<Product>();
        }
        
    }
}
