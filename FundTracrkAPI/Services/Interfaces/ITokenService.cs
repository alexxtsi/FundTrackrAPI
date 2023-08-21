using FundTracrkAPI.Models.DBmodels;

namespace FundTracrkAPI.Services.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(UserModel user);
	}
}
