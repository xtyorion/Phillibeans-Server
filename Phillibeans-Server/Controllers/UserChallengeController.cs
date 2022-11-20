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
    public class UserChallengeController : ControllerBase
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
            var challengeId = new ObjectId(request.ChallengeId);
            var userId = new ObjectId(request.Id);

            var userChallengeDoc = _userChallengeRepository.GetUserChallenge(userId, challengeId);
           
            userChallenge.Challenge_Id = challengeId;
            userChallenge.User_Id = userId;
            var doc = new BsonDocument { userChallenge.ToBsonDocument() };
           

            if (userChallengeDoc == null)
            {
                _userChallengeRepository.Insert(doc);

            }
            else
            {
               // _userChallengeRepository.Update(doc);
            }
            //update or add

            return BadRequest(userChallenge);

        }
    }
}
