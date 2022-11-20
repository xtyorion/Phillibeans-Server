using Phillibeans_Server.Models;

using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharpCompress.Common;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace Phillibeans_Server.Data.Repositories 
{
    public class UserRepository : IRepository
    {
        private readonly PhillibeansDbContext _db;
        public UserRepository(PhillibeansDbContext db)
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

            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var user = _db.getCollection().Find(filter).FirstOrDefault();
            return user;

        }

        public BsonDocument Insert(IDocument entity)
        {
            throw new NotImplementedException();
        }

        public long Update(ObjectId id, string key, string value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var result = _db.UpdateOne(filter, key, value);
            return result;
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

        public void setCollection(string str)
        {
            _db.setCollection(str);
        }
    }


}
