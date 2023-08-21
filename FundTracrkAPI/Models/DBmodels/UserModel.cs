using System.ComponentModel.DataAnnotations;

namespace FundTracrkAPI.Models.DBmodels
{
	public class UserModel
	{
		[Key]
		public int? UserId { get; set; }
		[Required]
		public string? UserName { get; set; }

		public string? UserFirstName { get; set; }

		public string? UserLastName { get; set; }

		[Required]
		public string? UserEmail { get; set; }

		public string? UserPhone { get; set; }

		public byte[]? PasswordHash { get; set; }

		public byte[]? PasswordSalt { get; set; }


	}
}
