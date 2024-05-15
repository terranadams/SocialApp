using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController: BaseApiController { // AccountController handles user registration and login functionalities.

        private readonly DataContext _context; // Inject DataContext for database operations.
        private readonly ITokenService _tokenService; 

        public AccountController(DataContext context, ITokenService tokenService) {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")] // POST api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            // Check if the username is already taken.
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512(); // Create a password hash and salt.

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return new UserDto {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username); // this fetches our db for the username passed into the loginDto (login page)

            if (user == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            // Check if the computed hash matches the stored password hash.
            for (int i = 0; i < computedHash.Length; i++) {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            // if the username and passwords match what's in the db, return the user
            return new UserDto {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

        }

        private async Task<bool> UserExists(string username) 
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());// here we're checking to see if a user exists prior to registering them
        }
    }
}