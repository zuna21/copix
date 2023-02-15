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
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register/journalist")] // POST: api/account/register/journalist
        public async Task<ActionResult<JournalistDto>> RegisterJournalist(RegisterJournalistDto registerJournalistDto)
        {
            if(await UserExists(registerJournalistDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();
            var journalist = new Journalist
            {
                UserName = registerJournalistDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(
                    registerJournalistDto.Password
                )),
                PasswordSalt = hmac.Key
            };

            _context.Journalists.Add(journalist);
            await _context.SaveChangesAsync();
            return new JournalistDto
            {
                Username = journalist.UserName,
                Token = _tokenService.CreateToken(journalist)
            };
        }

        [HttpPost("login/journalist")] // POST: api/account/login/journalist
        public async Task<ActionResult<JournalistDto>> LoginJournalist(LoginJournalistDto loginJournalistDto)
        {
            var journalist = await _context.Journalists.FirstOrDefaultAsync(x => 
                x.UserName == loginJournalistDto.Username);
            if(journalist == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(journalist.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginJournalistDto.Password));
            for(int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != journalist.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new JournalistDto
            {
                Username = journalist.UserName,
                Token = _tokenService.CreateToken(journalist)
            };
        }
        
        private async Task<bool> UserExists(string username)
        {
            return await _context.Journalists.AnyAsync(x => x.UserName
                == username.ToLower());
        }
    }
}