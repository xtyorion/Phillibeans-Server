using Phillibeans_Server.Models;

using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharpCompress.Common;

namespace Phillibeans_Server.Data.Repositories 
{
    public class ChallengeTypesRepository : IRepository
    {
        private readonly PhillibeansDbContext _db;
        public ChallengeTypesRepository(PhillibeansDbContext db)
        {
            this._db = db;
            
        }

        public IEnumerable<BsonDocument> GetAll()
        {
            var result = _db.findAll().ToList();
            return result;
        }

        public BsonDocument GetById(ObjectId id)
{

            var filter = Builders<BsonDocument>.Filter.Eq("ChallengeTypeId", id);
            var user = _db.getCollection().Find(filter).FirstOrDefault();
            return user;

        }

        public BsonDocument GetChallengeType(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            return _db.getCollection().Find(filter).FirstOrDefault();
        }

        public BsonDocument Insert(BsonDocument entity)
        {
            var type = entity.ToBsonDocument();
            _db.Add(type);
            return type;
        }

        public int Delete(BsonDocument doc)
        {
            var userAlreadyExists = _db.getCollection().Find(doc).ToList();
            int Result = 0;
            if (userAlreadyExists != null)
            {
                _db.deleteOne(doc);
                Result = 1;
            }
            return Result;
        }

        public void setCollection(string col)
        {
            _db.setCollection(col);
        }
    }


}
