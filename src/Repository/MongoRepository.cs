using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Repository
{
    public abstract class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Properties

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<BsonDocument> _collection;

        #endregion

        #region Ctor

        public MongoRepository(string stringconnection, string collection)
        {
            _client = new MongoClient(stringconnection);
            _database = _client.GetDatabase(collection);
            _collection = _database.GetCollection<BsonDocument>(typeof(TEntity).Name);
        }

        #endregion

        #region Methods

        public virtual void Insert(TEntity obj)
        {
            _collection.InsertOne(obj.ToBsonDocument());
        }

        public virtual void Remove(Guid id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("ID", id);
            _collection.DeleteOne(filter);
        }

        public virtual void Update(TEntity obj)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("ID", obj.GetType().GetProperty("ID").GetValue(obj, null));
            var objMongo = _collection.Find(filter).FirstOrDefault();

            if (objMongo != null)
                _collection.ReplaceOne(objMongo, obj.ToBsonDocument());

        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var objs = _collection.Find(_ => true).ToList();

            if (objs != null)
            {
                objs.ForEach(o => o.Remove("_id"));
                return BsonSerializer.Deserialize<IEnumerable<TEntity>>(objs.ToJson());
            }

            return null;
        }

        public virtual TEntity GetById(Guid id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("ID", id);
            var obj = _collection.Find(filter).FirstOrDefault();

            if (obj != null)
            {
                obj.Remove("_id");
                return BsonSerializer.Deserialize<TEntity>(obj);
            }

            return null;
        }

        #endregion

    }
}
