using FundTracrkAPI.Models.DBmodels;
using Microsoft.EntityFrameworkCore;

namespace FundTracrkAPI.DBManager
{
    public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{ }

		public DbSet<UserModel> Users { get; set; }
	}
}
