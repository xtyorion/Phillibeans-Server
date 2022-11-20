using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Phillibeans_Server.Models;

namespace Phillibeans_Server.Data.Repositories
{
    public class UserChallengeRepository
    {
        private readonly PhillibeansDbContext _db;
        public UserChallengeRepository(PhillibeansDbContext db)
        {
            this._db = db;
        }

        public BsonDocument GetUserChallenge(ObjectId id, ObjectId challenge_id)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Challenge_Id", id) & builder.Eq("User_Id", challenge_id);
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
