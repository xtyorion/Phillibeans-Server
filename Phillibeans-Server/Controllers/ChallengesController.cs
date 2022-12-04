using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Phillibeans_Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using Phillibeans_Server.Data.Repositories;

namespace Phillibeans_Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChallengesController : ControllerBase
    {
        private readonly ChallengeRepository _ChallengesRepository;
        public ChallengesController(ChallengeRepository ChallengesRepository) 
        {
            this._ChallengesRepository = ChallengesRepository;
            this._ChallengesRepository.setCollection("Challenges");
        }

        [HttpGet]
        [Route("")]
        public Task<string> GetAll()
        {
            var challengeDoc = _ChallengesRepository.GetAll();
            var challenge = challengeDoc.Select(v=>BsonSerializer.Deserialize<Challenges>(v)).ToList();
            return Task.FromResult(challenge.ToJson());
        } 

        [HttpGet]
        [Route("{id}")]
        public Task<string> GetAsync([FromRoute] string id)
        {
            var challengeId = new ObjectId(id);
            var challengeDoc = _ChallengesRepository.GetById(challengeId);
            var challenge = BsonSerializer.Deserialize<User>(challengeDoc).ToJson();
            return Task.FromResult(challenge);
        }
        string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
         [HttpPost]
        public async Task<ActionResult<Challenges>> InsertChallenge(ChallengeDto request)
        {
            var challenge = _ChallengesRepository.GetByName(request.Name);

            if (challenge == null)
            {
                var newChallenge = new Challenges();
                newChallenge.Id = new ObjectId().ToString();
                newChallenge.Name = request.Name;
                newChallenge.typeID =request.typeID;
                newChallenge.categoryID = request.categoryID;
                var doc = new BsonDocument { newChallenge.ToBsonDocument() };
                var newDoc = _ChallengesRepository.Insert(doc);


                _ChallengesRepository.AppendToCategories(newDoc, newChallenge.categoryID);
                

                return Ok();
            }
            return BadRequest("Item already exists.");
        }
        /* public int Post()
         {
             string file = dir + @"\\Data\\testdata\\Challenges.json";
             using (StreamReader r = new StreamReader(file))
             {
                 string json = r.ReadToEnd();
                 var challengeInfo = JsonConvert.DeserializeObject<Challenges>(json);
                  var id = challengeInfo.Id;
                 var doc = new BsonDocument { challengeInfo.ToBsonDocument() };

                 var filter = Builders<BsonDocument>.Filter.Eq("User.Name", id);
                 var result = _ChallengesRepository.Insert(doc);
                  var count = result.Count();
                  return count;
             }
         }*/
    }
}
