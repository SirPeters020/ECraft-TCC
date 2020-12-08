using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecraft.Api.Models;
using System.Text;
using Ecraft.Api.Data.Repositories.UnitsOfWork;

namespace Ecraft.Api.Controllers
{
    // https://localhost:44313/v1/auth
    [Route("v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly JWTSettings _jwtsettings;
        private readonly UnitOfWorkUser _unit;

        public AuthController(IOptions<JWTSettings> jwtsettings, UnitOfWorkUser unit)
        {
            _unit = unit;
            _jwtsettings = jwtsettings.Value;
        }


        // v1/auth/login
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Authentication([FromBody] User model)
        {
            string cryptoEmail = _unit.UserRepo.EncryptParam(model.Email);
            string cryptoPassword = _unit.UserRepo.EncryptParam(model.Password);
            var users = await _unit.UserRepo.GetAsync(x => (x.Email == cryptoEmail && x.Password == cryptoPassword));
            User user = new User()
            {
                Id = 1,
                Name = "Pedro Augusto",
                Email = "pedro.augusto@teste.com",
                Avatar = "/images/avatar/maxresdefault.jpg"
            };
            //var user = users.First();
            //user.Avatar = "/images/avatar/maxresdefault.jpg";
            if (user == null)
                return NotFound(new { message = "Email ou senha invalido" });

            var token = GenerateAccessToken(user);

            return new UserToken
            {
                User = user,
                Token = token
            };

        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Register([FromBody] User model)
        {
            var cryptoEmail = _unit.UserRepo.EncryptParam(model.Email);
            var cryptoPassword = _unit.UserRepo.EncryptParam(model.Password);
            var userExist = await _unit.UserRepo.GetAsync(x => (x.Email == cryptoEmail && x.Password == cryptoPassword));
            if(userExist.Count > 0)
                return NotFound(new { message = "Usuario ja existente" });

            _unit.UserRepo.Insert(model);
            await _unit.CommitAssync();


            var token = GenerateAccessToken(model);
            return new UserToken
            {
                User = model,
                Token = token
            };

        }

        private string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
