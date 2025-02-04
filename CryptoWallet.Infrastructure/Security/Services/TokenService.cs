using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PSS.DHPM.CryptoWallet.Core.Domain.Entities;
using PSS.DHPM.CryptoWallet.Core.Security.Interfaces;
using PSS.DHPM.CryptoWallet.Core.Security.Models;

namespace PSS.DHPM.CryptoWallet.Infrastructure.Security.Services
{
	public class TokenService : ITokenService
	{
		private readonly TokenSettings _settings;
		public TokenService(IOptions<TokenSettings> settings)
		{
			_settings = settings.Value;
		}
		public string GenerateJwtToken(User user)
		{
			var claims = new[]
			{
			new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
			new Claim(ClaimTypes.Email, user.Email),
			new Claim(ClaimTypes.Name, user.Username)
		};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _settings.Issuer,
				audience: _settings.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(_settings.ExpirationMinutes),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
		public bool ValidateToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(_settings.Key)),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = _settings.Issuer,
					ValidAudience = _settings.Audience,
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				return true;
			}
			catch
			{
				return false;
			}
		}
		public ClaimsPrincipal GetPrincipalFromToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(_settings.Key)),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = _settings.Issuer,
					ValidAudience = _settings.Audience,
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				return principal;
			}
			catch
			{
				return null;
			}
		}
	}
}