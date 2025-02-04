using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PSS.DHPM.CryptoWallet.Core.Domain.Entities;

namespace PSS.DHPM.CryptoWallet.Core.Security.Interfaces
{
	public interface ITokenService
	{
		string GenerateJwtToken(User user);
		bool ValidateToken(string token);
		ClaimsPrincipal GetPrincipalFromToken(string token);
	}
}
