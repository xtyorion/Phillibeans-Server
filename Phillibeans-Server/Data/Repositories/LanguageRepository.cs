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
    public class LanguageRepository : IRepository
    {
        private readonly PhillibeansDbContext _db;
        public LanguageRepository(PhillibeansDbContext db)
        {
            this._db = db;
           
        }

        public IEnumerable<BsonDocument> GetAll()
        {
            var result = _db.findAll().ToList();
            return result;
        }

        public BsonDocument GetById(int id)
{

            var filter = Builders<BsonDocument>.Filter.Eq("LanguageId", id);
            var Language = _db.getCollection().Find(filter).FirstOrDefault();
            return Language;

        }

        public BsonDocument Insert(IDocument entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(BsonDocument doc)
        {
            var LanguageAlreadyExists = _db.getCollection().Find(doc).ToList();
            int Result = 0;
            if (LanguageAlreadyExists != null)
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
