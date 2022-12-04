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
        public ActionResult GetAll()
        {
            List<ChallengeCategories>? challenge = null;
            try
            {
                var challengeDoc = _ChallengeCategoryRepository.GetAll();
                challenge = challengeDoc.Select(v => BsonSerializer.Deserialize<ChallengeCategories>(v)).ToList();
            }
            catch (Exception e)
            {

            }
            return Json(challenge);
        }
        [HttpPost]
        public async Task<ActionResult<ChallengeCategories>> InsertCategory(ChallengeCategoryDto request)
        {
            var challengeCatDoc = _ChallengeCategoryRepository.GetChallengeCategory(request.Name);
            if(challengeCatDoc == null)
            {
                var cat = new ChallengeCategories();
                cat.Id = new ObjectId().ToString();
                cat.Name = request.Name;
                var doc = new BsonDocument { cat.ToBsonDocument() };
                _ChallengeCategoryRepository.Insert(doc);
                return Ok();
            }
            return BadRequest("Item already exists.");
        }
      
    }
}
