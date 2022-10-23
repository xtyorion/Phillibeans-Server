using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Phillibeans_Server.Models;
using Microsoft.Extensions.Options;

namespace Phillibeans_Server
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PhillibeansDbContext _db;

        public UserController(PhillibeansDbContext db)
        {
            this._db = db;
            db.setCollection("User");
        }

        string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        //[HttpGet]
        //[Route("{email}")]
        //public BsonDocument Get()
        //{
        //    string email = "email22@123.com";
        //    var filter = Builders<BsonDocument>.Filter.Eq("User.Email", email);
        //    var userAlreadyExists = _db.getCollection().Find(filter).FirstOrDefault();
        //    return userAlreadyExists;
        //}
        [HttpGet]
        [Route("{id}")]
        public Task<string> GetAsync([FromRoute] int id) 
        {
            var filter = Builders<BsonDocument>.Filter.Eq("User._id", id);
            var user = _db.getCollection().Find(filter).ToList().ToJson();
            return Task.FromResult(user);
        }


        //[HttpPost]
        //public int Post()
        //{
        //    string file = dir + @"\\Data\\testdata\\User.json";
        //    using (StreamReader r = new StreamReader(file))
        //    {
        //        string json = r.ReadToEnd();
        //        var userInfo = JsonConvert.DeserializeObject<UserRoot>(json);
        //        var id = userInfo.User.Name;
        //        var doc = new BsonDocument { userInfo.ToBsonDocument() };

        //        var filter = Builders<BsonDocument>.Filter.Eq("User.Name", id);
        //        var userAlreadyExists = _db.getCollection().Find(filter).ToList();
        //        if (userAlreadyExists.Count > 0)
        //        {
        //            _db.deleteOne(doc);
        //        }
        //        var result = 0;
        //        result = _db.Add(doc);
        //        return result;
        //    }
        //}
    }
}