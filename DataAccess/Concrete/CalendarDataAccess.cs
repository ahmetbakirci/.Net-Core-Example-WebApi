using Core.DataAccess.DbSettings;
using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.Repository;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Concrete
{
    public class CalendarDataAccess: MongoRepositoryBase<Calendar>,ICalendarDataAccess
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Calendar> _collection;

        public CalendarDataAccess(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<Calendar>();
        }
    }
}
