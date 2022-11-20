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
    public class ChallengeCategoryController : Controller
    {
        private readonly ChallengeCategoriesRepository _ChallengeCategoryRepository;
        public ChallengeCategoryController(ChallengeCategoriesRepository ChallengesRepository)
        {
            this._ChallengeCategoryRepository = ChallengesRepository;
            this._ChallengeCategoryRepository.setCollection("ChallengeCategories");
        }

        [HttpGet]
        [Route("")]
        public Task<List<ChallengeCategories>> GetAll()
        {
            var challengeDoc = _ChallengeCategoryRepository.GetAll();
            var challenge = challengeDoc.Select(v => BsonSerializer.Deserialize<ChallengeCategories>(v)).ToList();
            return Task.FromResult(challenge);
        }
        [HttpPost]
        public async Task<ActionResult<ChallengeCategories>> InsertCategory(ChallengeCategoryDto request)
        {
            var challengeCatDoc = _ChallengeCategoryRepository.GetChallengeCategory(request.Name);
            if(challengeCatDoc == null)
            {
                var doc = new BsonDocument {  };
                _ChallengeCategoryRepository.Insert((IDocument)doc);
                return Ok();
            }
            return BadRequest("Item already exists.");
        }
    }
}
