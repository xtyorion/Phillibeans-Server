using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Phillibeans_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using Phillibeans_Server.Data.Repositories;

namespace Phillibeans_Server
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._userRepository.setCollection("User");
        }

        //string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        [HttpGet]
        [Route("{id}")]
        public Task<string> GetAsync([FromRoute] string id)
        {
            var userId = new ObjectId(id);
            var userDoc = _userRepository.GetById(userId);
            var user = BsonSerializer.Deserialize<User>(userDoc).ToJson();
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