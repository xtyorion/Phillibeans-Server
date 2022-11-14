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
    public class SolutionsRepository : IRepository
    {
        private readonly PhillibeansDbContext _db;
        public SolutionsRepository(PhillibeansDbContext db)
        {
            this._db = db;
            _db.setCollection("Solutions");
        }

        public IEnumerable<BsonDocument> GetAll()
        {
            var result = _db.findAll().ToList();
            return result;
        }

        public BsonDocument GetById(int id)
{

            var filter = Builders<BsonDocument>.Filter.Eq("SolutionId", id);
            var user = _db.getCollection().Find(filter).FirstOrDefault();
            return user;

        }

        public BsonDocument Insert(IDocument entity)
        {
            throw new NotImplementedException();
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
