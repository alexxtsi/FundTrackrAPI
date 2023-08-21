using FundTracrkAPI.DBManager;
using FundTracrkAPI.Models.APIModels;
using FundTracrkAPI.Models.DBmodels;
using FundTracrkAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace FundTracrkAPI.Controllers
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
		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (await UserNameExists(registerDto.UserName)) return BadRequest("UserName alredy taken");
			using var hmac = new HMACSHA512();


			var user = new UserModel
			{
				UserName = registerDto.UserName,
				PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
				PasswordSalt = hmac.Key
			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return new UserDto {UserName=user.UserName, Token=_tokenService.CreateToken(user) };
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> login(LoginDto loginDto)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x =>
				x.UserName == loginDto.UserName);

			if (user == null) return Unauthorized();

			using var hmac = new HMACSHA512(user.PasswordSalt);

			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password)); ;

			for (var i = 0; i < computedHash.Length; i++)
			{
				if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("invalid password");
			}

			return new UserDto { UserName = user.UserName, Token = _tokenService.CreateToken(user) };
		}

		private async Task<bool> UserNameExists(string UserName)
		{
			return await _context.Users.AnyAsync(x => x.UserName == UserName); //UserName.toLowercase() ?
		}
	}
}
