using Microsoft.IdentityModel.Tokens;
using PerfumeApiBackend.Models;
using System.Composition;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PerfumeApiBackend.Helpers.Jwt
{
    public enum Category
    {
        Super,
        Admin,
        User
    }


    public static class JwtHelpers
    {
        
        public static IEnumerable<Claim> GetClaims( UserToken userToken, Guid id )
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", userToken.Id.ToString()),
                new Claim(ClaimTypes.Name, userToken.UserName),
                new Claim(ClaimTypes.Email, userToken.EmailId),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };

            if (userToken.Category == Category.Super.ToString())
            {
                claims.Add(new Claim(ClaimTypes.Role, Category.Super.ToString()));
            }
            else if (userToken.Category == Category.Admin.ToString())
            {
                claims.Add(new Claim(ClaimTypes.Role, Category.Admin.ToString()));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, Category.User.ToString()));
            }

            return claims;

        }

        public static IEnumerable<Claim> GetClaims(UserToken userToken, out Guid id)
        {
            id = Guid.NewGuid();
            return GetClaims(userToken, id);
        }

        public static JwtHeader GetJwtHeader(JwtSettings jwtSettings)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            return new JwtHeader(_signingCredentials);
        }

        public static JwtPayload GetPayLoad(UserToken userToken, JwtSettings jwtSettings, DateTime expire, out Guid Id)
        {
            return new JwtPayload(issuer: jwtSettings.ValidIssuer,
                                  audience: jwtSettings.ValidAudience,
                                  claims: GetClaims(userToken, out Id),
                                  notBefore: new DateTimeOffset(DateTime.Now).DateTime, // decimos que no este disponible antes de hoy
                                  expires: new DateTimeOffset(expire).DateTime//caducidad en 1 dia);
                                 );
        }

        public static UserToken GetToken(UserToken userToken, JwtSettings jwtSettings)
        {
            try
            {
                if (userToken == null)
                {
                    throw new ArgumentException(nameof(userToken));
                }

                Guid Id = new Guid();
                DateTime expireToken = DateTime.UtcNow.AddDays(1);

                var jwtHeader = GetJwtHeader(jwtSettings);
                var jwtPayLoad = GetPayLoad(userToken, jwtSettings, expireToken, out Id);

                /*
                var jwtPayLoad = 
                    new JwtPayload(
                                    issuer: jwtSettings.ValidIssuer,
                                    audience: jwtSettings.ValidAudience,
                                    claims: GetClaims(userToken, Id),
                                    notBefore: new DateTimeOffset(DateTime.Now).DateTime, // decimos que no este disponible antes de hoy
                                    expires: new DateTimeOffset(expire).DateTime//caducidad en 1 dia
                                    );
                */

                var token = new JwtSecurityToken(jwtHeader, jwtPayLoad);
                var signedToken = new JwtSecurityTokenHandler().WriteToken(token);

                var UserTokenResult = new UserToken();

                UserTokenResult.Id = userToken.Id;
                UserTokenResult.Token = signedToken;
                UserTokenResult.UserName = userToken.UserName;
                UserTokenResult.Validity = expireToken.TimeOfDay;
                UserTokenResult.Guid = Id;
                UserTokenResult.Category = userToken.Category;

                return UserTokenResult;
            }
            catch (Exception ex)
            {

                throw new Exception("Error generating the JWT", ex);
            }


        }



    }
}
