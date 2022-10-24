using MongoDB.Bson;
using MongoDB.Driver;
using Phillibeans_Server.Models;

namespace Phillibeans_Server.Data.Repositories
{
    public interface IRepository
    {
       IEnumerable<BsonDocument> GetAll();

       BsonDocument GetById(int id);

       BsonDocument Insert(IDocument entity);

       int Delete(BsonDocument doc);
    }
}
