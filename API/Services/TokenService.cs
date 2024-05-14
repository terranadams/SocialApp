using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;


namespace API.Services
{
    public class TokenService : ITokenService
    {

        private readonly SymmetricSecurityKey _key; // _key holds the symmetric security key used for signing the token.
        
        
        public TokenService (IConfiguration config) { // Constructor takes the IConfiguration object to access application settings like the token key.
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])); // Initialize the symmetric security key with the key stored in app settings.
        }
        public string CreateToken(AppUser user) { // CreateToken generates a JWT token for the specified user.

            // Define claims to be included in the token, such as the username.
            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            // Create signing credentials using the security key and HMAC-SHA512 signing algorithm.
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // Describe the token: set the claims, expiration time, and signing credentials.
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7); // this means the token will expire after a week
                SigningCredentials = creds;
            };

            // Create a JwtSecurityTokenHandler instance to handle the token creation.
            var tokenHandler = new JwtSecurityTokenHandler();

            // Create the token based on the descriptor.
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the serialized token as a string.
            return tokenHandler.WriteToken(token);
        }
    }
}