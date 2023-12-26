using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IsBankWebApiTutorial.Models.AuthOperations
{
    public class IsBankTokenHandler
    {
        //create access token
        public Token CreateAccessToken(string email)
        {

            var claimsData = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email),
            };

            var token = new Token();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("loremipsumloremipsumloremipsumloremipsumloremipsumloremipsum"));

            //token icin sifreleme algoritmasi belirleme
            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            token.ExpirationDate = DateTime.Now.AddMinutes(30);

            //token ozelliklerini belirleme
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                               issuer: "mail@isbank.com",
                               audience: "mail@isbank.com",
                               claims: claimsData,
                               expires: token.ExpirationDate,
                               signingCredentials: signingCredentials);

            //token create
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}

