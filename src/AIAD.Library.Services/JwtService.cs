using AIAD.Library.Global;
using AIAD.Library.Models;
using AIAD.Library.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AIAD.Library.Services
{
    /// <summary>
    /// http://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api
    /// </summary>
    public class JwtService : IJwtService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private IList<JwtUser> users = new List<JwtUser>
        {
            new JwtUser { Id = "6761d1ea-06bb-4c3e-b24e-8a7865bf094b", Username = "superkarn@gmail.com", Token = "12345abcde" }
        };

        private readonly JwtAppSettings jwtAppSettings;

        public JwtService(JwtAppSettings jwtAppSettings)
        {
            this.jwtAppSettings = jwtAppSettings;
        }

        public JwtUser Authenticate(string apiToken)
        {
            // TODO authenticate credential against the database
            // users hardcoded for simplicity, store in a db with hashed passwords in production applications
            var user = this.users.SingleOrDefault(x => x.Token == apiToken);

            if (user == null)
            {
                return user;
            }

            // Authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtAppSettings.Key));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = this.jwtAppSettings.Issuer,
                Audience = this.jwtAppSettings.Audience,
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("username", user.Username),
                    new Claim("userId", user.Id),
                }),
                Expires = DateTime.UtcNow.AddSeconds(this.jwtAppSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}
