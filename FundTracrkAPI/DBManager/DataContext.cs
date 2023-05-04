using FundTracrkAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FundTracrkAPI.DBManager
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{ }

		public DbSet<UserData> Users { get; set; }
	}
}
