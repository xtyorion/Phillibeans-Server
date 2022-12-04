using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Phillibeans_Server.Models;
using System.Reflection.Metadata;

namespace Phillibeans_Server.Data.Repositories
{
    public class UserChallengeRepository
    {
        private readonly PhillibeansDbContext _db;
        public UserChallengeRepository(PhillibeansDbContext db)
        {
            this._db = db;
        }

        public IEnumerable<BsonDocument> GetAllById(string id)
        {
            var builder = Builders<BsonDocument>.Filter;
            ObjectId user_id = new ObjectId(id);
            var filter = builder.Eq("User_Id", user_id);
            var docs = _db.getCollection().Find(filter).ToList();

            return docs;
        }

        public BsonDocument GetUserChallenge(string user_id, string challenge_id)
        {

            var challengeId = new ObjectId(challenge_id);
            var userId = new ObjectId(user_id);
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Challenge_Id", challengeId) & builder.Eq("User_Id", userId);
            var doc = _db.getCollection().Find(filter).FirstOrDefault();

            return doc;

        }

        public BsonDocument Insert(BsonDocument doc)
        {
            if (doc != null)
            {
                if (_db.Add(doc) == 1)
                {
                    return doc;
                }
                return doc;
            }
            return doc;
        }

        public void Update(BsonDocument doc, Challenges_Users item)
        {
            if (doc != null)
            {
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Challenge_Id", new ObjectId(item.Challenge_Id)) & builder.Eq("User_Id", new ObjectId(item.User_Id));
                var update = Builders<BsonDocument>.Update.Set("Status", item.Status);
                
                foreach (BsonElement el in doc)
                {
                    update = update.Set(el.Name, el.Value);
                }

                var result = _db.getCollection().UpdateOne(filter, update);
            }
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
