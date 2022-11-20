using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Phillibeans_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using Phillibeans_Server.Data.Repositories;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;

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

        [HttpGet]
        [Route("")]
        public Task<List<User>> GetAllAsync()
        {
            var userDocs = _userRepository.GetAll();
            var users = userDocs.Select(v => BsonSerializer.Deserialize<User>(v)).ToList();
            return Task.FromResult(users);
        }

        [HttpPut]
        [Route("{id}/{key}")]
        public Task<long> Update([FromRoute] string id, [FromRoute] string key, [FromBody] string value)
        {
            var userId = new ObjectId(id);
            var result = _userRepository.Update(userId, key, value);
            return Task.FromResult(result);

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