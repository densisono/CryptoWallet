using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.DHPM.CryptoWallet.Core.Domain.Interfaces;
using PSS.DHPM.CryptoWallet.Core.Security.Interfaces;
using PSS.DHPM.CryptoWallet.Core.Security.Models;
using PSS.DHPM.CryptoWallet.Infrastructure.Data.Context;
using PSS.DHPM.CryptoWallet.Infrastructure.Data.Repositories;
using PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Interfaces;
using PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Services;
using PSS.DHPM.CryptoWallet.Infrastructure.Security.Services;

namespace PSS.DHPM.CryptoWallet.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CryptoWalletContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			// Security Services
			services.Configure<TokenSettings>(configuration.GetSection("Jwt"));
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IEncryptionService, EncryptionService>();
			services.AddScoped<IPasswordHasher, PasswordHasher>();
			// API Clients
			services.AddHttpClient<IBinanceApiClient, BinanceApiClient>();
			services.AddHttpClient<ICoinGeckoApiClient, CoinGeckoApiClient>();
			services.AddHttpClient<IOkexApiClient, OkexApiClient>();
			return services;
		}
	}
}/