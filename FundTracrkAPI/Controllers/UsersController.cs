using FundTracrkAPI.DBManager;
using FundTracrkAPI.Models.DBmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundTracrkAPI.Controllers
{
    public class UsersController : BaseApiController
	{
		private readonly DataContext _context;
		public UsersController(DataContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
		{
			return await _context.Users.ToListAsync();

		}
		
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<UserModel>> GetUserById(int id)
		{
			return await _context.Users.FindAsync(id);
		}

	}
}
