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
    public class ChallengeRepository : IRepository
    {
        private readonly PhillibeansDbContext _db;
        public ChallengeRepository(PhillibeansDbContext db)
        {
            this._db = db;
            _db.setCollection("Challenge");
        }

        public IEnumerable<BsonDocument> GetAll()
        {
            var result = _db.findAll().ToList();
            return result;
        }

        public BsonDocument GetById(ObjectId id)
{

            var filter = Builders<BsonDocument>.Filter.Eq("ChallengeId", id);
            var challenge = _db.getCollection().Find(filter).FirstOrDefault();
            return challenge;

        }
        public BsonDocument GetByName(string name)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("Name", Name);
            var user = _db.getCollection().Find(filter).FirstOrDefault();
            return user;

        }

        public BsonDocument Insert(BsonDocument entity)
        {
            var challenge = entity;
            _db.Add(challenge);
            return challenge;
        }

        public BsonDocument AppendToCategories(BsonDocument entity, string CategoryID)
        {
            var Categories = _db.getMongo().GetCollection<BsonDocument>("ChallengeCategories");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(CategoryID));

            var pushCountryDefinition = Builders<BsonDocument>
           .Update.Push("Challenges", entity);

            Categories.UpdateOneAsync(filter, pushCountryDefinition);
            return entity;
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
