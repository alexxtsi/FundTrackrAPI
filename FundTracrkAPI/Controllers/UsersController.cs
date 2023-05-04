using FundTracrkAPI.DBManager;
using FundTracrkAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundTracrkAPI.Controllers
{
	[Route("api/[controller]")] //Api users
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly DataContext _context;
		public UsersController(DataContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserData>>> GetUsers()
		{
			return await _context.Users.ToListAsync();

		}
		[HttpGet("{id}")]
		public async Task<ActionResult<UserData>> GetUserById(int id)
		{
			return await _context.Users.FindAsync(id);
		}
	}
}
