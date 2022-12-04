using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Phillibeans_Server.Data.Repositories;
using Phillibeans_Server.Models;
using System;

namespace Phillibeans_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserChallengeController : Controller
    {
        public static Challenges_Users userChallenge = new Challenges_Users();
        private readonly UserChallengeRepository _userChallengeRepository;

        public UserChallengeController(UserChallengeRepository userChallengeRepository)
        {
            this._userChallengeRepository = userChallengeRepository;
            this._userChallengeRepository.setCollection("UserChallenge");
        }
        //update user challenges
        [HttpPost("UpdateUserChallenge")]
        public async Task<ActionResult<Challenges_Users>> UpdateUserChallenge(Challenges_Users_Dto request)
        {

            var userChallengeDoc = _userChallengeRepository.GetUserChallenge(request.User_Id, request.Challenge_Id);
            
            userChallenge.Challenge_Id = request.Challenge_Id;
            userChallenge.Id = new ObjectId().ToString();
            if (request._id != "")
                userChallenge.Id = request._id;
            
            userChallenge.User_Id = request.User_Id;
            userChallenge.Status = request.Status;
       
            var doc = new BsonDocument { userChallenge.ToBsonDocument() };
           

            if (userChallengeDoc == null)
            {
                _userChallengeRepository.Insert(doc);

            }
            else
            {
                
               _userChallengeRepository.Update(doc, userChallenge);
            }
            //update or add

            return Ok(userChallenge);

        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetAllById([FromRoute] string id)
        {
            var challengeDoc = _userChallengeRepository.GetAllById(id);
            var challenge = challengeDoc.Select(v => BsonSerializer.Deserialize<Challenges_Users>(v)).ToList();
            return Json(challenge);
        }
    }
}
