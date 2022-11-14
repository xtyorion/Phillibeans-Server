﻿using Microsoft.AspNetCore.Mvc;
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
        public Task<List<Challenges>> GetAll()
        {
            var challengeDoc = _ChallengesRepository.GetAll();
            var challenge = BsonSerializer.Deserialize<List<Challenges>>((BsonDocument)challengeDoc);
            return Task.FromResult(challenge);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<string> GetAsync([FromRoute] int id)
        {
            var challengeDoc = _ChallengesRepository.GetById(id);
            var challenge = BsonSerializer.Deserialize<User>(challengeDoc).ToJson();
            return Task.FromResult(challenge);
        }
        string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        [HttpPost]
       public int Post()
       {
           string file = dir + @"\\Data\\testdata\\Challenges.json";
           using (StreamReader r = new StreamReader(file))
           {
               string json = r.ReadToEnd();
               var challengeInfo = JsonConvert.DeserializeObject<Challenges>(json);
                var id = challengeInfo.Id;
               var doc = new BsonDocument { challengeInfo.ToBsonDocument() };

               var filter = Builders<BsonDocument>.Filter.Eq("User.Name", id);
               var result = _ChallengesRepository.Insert(challengeInfo);
                var count = result.Count();
                return count;
           }
       }
    }
}
