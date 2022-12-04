using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Phillibeans_Server.Data.Repositories;
using Phillibeans_Server.Models;

namespace Phillibeans_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeTypeController : Controller
    {
        private readonly ChallengeTypesRepository _ChallengeTypesRepository;
        public ChallengeTypeController(ChallengeTypesRepository ChallengeTypesRepository)
        {
            this._ChallengeTypesRepository = ChallengeTypesRepository;
            this._ChallengeTypesRepository.setCollection("ChallengeTypes");
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetAll()
        {
            List<ChallengeTypes>? challenge = null;
            try
            {
                var challengeDoc = _ChallengeTypesRepository.GetAll();
                challenge = challengeDoc.Select(v => BsonSerializer.Deserialize<ChallengeTypes>(v)).ToList();
                
            }
            catch (Exception e)
            {

            }
            return Json(challenge);
        }
        [HttpPost]
        public async Task<ActionResult<ChallengeTypes>> InsertCategory(ChallengeTypeDto request)
        {
            var challengeCatDoc = _ChallengeTypesRepository.GetChallengeType(request.Name);
            if (challengeCatDoc == null)
            {
                var type = new ChallengeTypes();
                type.Name = request.Name;
                var doc = new BsonDocument { type.ToBsonDocument() };
                _ChallengeTypesRepository.Insert(doc);
                return Ok();
            }
            return BadRequest("Item already exists.");
        }
    }
}

