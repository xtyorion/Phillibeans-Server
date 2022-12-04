using Phillibeans_Server.Models;

using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharpCompress.Common;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace Phillibeans_Server.Data.Repositories 
{
    public class ChallengeCategoriesRepository : IRepository
    {
        private readonly PhillibeansDbContext _db;
        public ChallengeCategoriesRepository(PhillibeansDbContext db)
        {
            this._db = db;
           
        }

        public IEnumerable<BsonDocument> GetAll()
        {
            var result = _db.findAll().ToList();
            return result;
        }
        public BsonDocument GetChallengeCategory(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            var item = _db.getCollection().Find(filter).FirstOrDefault();
            return item;
        }
        public BsonDocument GetById(ObjectId id)
{

            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var user = _db.getCollection().Find(filter).FirstOrDefault();
            return user;

        }

        public BsonDocument Insert(BsonDocument entity)
        {
            var category = entity.ToBsonDocument();
            _db.Add(category);
            return category;
        }
        public BsonDocument InsertChallenge(BsonDocument entity, ObjectId categoryID)
        {
            var challenge = entity.ToBsonDocument();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", categoryID);

            var pushCountryDefinition = Builders<BsonDocument>
            .Update.Push("Challenges", challenge);

            _db.getCollection().UpdateOneAsync(filter, pushCountryDefinition);

            return challenge;
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
