using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Phillibeans_Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Phillibeans_Server.Controllers
{
    public class AuthController : Controller
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly PhillibeansDbContext _db;

        public AuthController(IConfiguration configuration, PhillibeansDbContext db)
        {
            _configuration = configuration;
            _db = db;
            
        }
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Name = request.Name;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var doc = new BsonDocument { user.ToBsonDocument() };
            _db.setCollection("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", user.Email);
            var userAlreadyExists = _db.getCollection().Find(filter).ToList();
            if (userAlreadyExists.Count == 0)
            {
                if (_db.Add(doc) == 1)
                {
                    return Ok(user);
                }
                return BadRequest(user);
            }
            return BadRequest(user);

        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            string email = request.Email;
            _db.setCollection("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            var resultdoc = _db.getCollection().Find(filter).FirstOrDefault();
            
            user = BsonSerializer.Deserialize<User>(resultdoc);
           
            /*  var userAlreadyExists = _db.getCollection().Find(filter);
              var resultdoc = userAlreadyExists.FirstOrDefault();
              var pHash = resultdoc["PasswordHash"].AsBsonArray.Select(p => p.AsString).ToArray();*/
            //var pHash = resultdoc.GetElement("PasswordHash");
            //string pSalt = resultdoc.GetValue("PasswordSalt").ToString();
            //char[] hash = new char[pHash.Length];
            //for (int i = 0; i < pHash.Length; i++)
            //{
            //    hash[i] = pHash[i];
            //}
            //char[] salt = new char[pSalt.Length];
            //for (int i = 0; i < pSalt.Length; i++)
            //{
            //    salt[i] = pSalt[i];
            //}

            //var passHash = hash.Select(c => (byte)c).ToArray();
            //var passSalt = salt.Select(c => (byte)c).ToArray();


            //byte[] = resultdoc.GetValue("PasswordHash");
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Bad user name or password.");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> _claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };       
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: _claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
}
