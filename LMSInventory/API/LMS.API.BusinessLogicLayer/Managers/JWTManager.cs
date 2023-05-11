using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.API.BusinessLogicLayer.Interfaces;
using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;

namespace LMS.API.BusinessLogicLayer.Managers
{
    public class JWTManager : IJWTManager
    {
        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
        {
            { "lms","lms"}
        };

        private readonly IConfiguration iconfiguration;
        public JWTManager(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        public TokenResDTO Authenticate(UserReqDTO users)
        {
            if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenResDTO { Token = tokenHandler.WriteToken(token) };

        }
    }
}
