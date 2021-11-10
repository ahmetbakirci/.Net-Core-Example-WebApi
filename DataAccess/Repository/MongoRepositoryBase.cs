using Core.DataAccess;
using Core.DataAccess.DbSettings;
using DataAccess.Contexts;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class MongoRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity:class,new()
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<TEntity>();
        }
        public TEntity Create(TEntity entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }
        public TEntity Update(string id, TEntity entity)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            _collection.ReplaceOne(filter, entity);
            return entity;
        }
        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            _collection.DeleteOne<TEntity>(filter);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _collection.Find<TEntity>(filter).FirstOrDefault();
        }
        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _collection.Find<TEntity>(TEntity => true).ToList() : _collection.AsQueryable().Where(filter).ToList();
        }
    }
}
