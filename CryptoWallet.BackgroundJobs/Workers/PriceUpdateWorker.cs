using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.BackgroundJobs.Workers
{
	public class PriceUpdateWorker : BackgroundService
	{
		private readonly ILogger<PriceUpdateWorker> _logger;
		private readonly ICryptoService _cryptoService;
		private readonly IConfiguration _configuration;
		public PriceUpdateWorker(ILogger<PriceUpdateWorker> logger, ICryptoService cryptoService, IConfiguration configuration)
		{
			_logger = logger;
			_cryptoService = cryptoService;
			_configuration = configuration;
		}
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				try
				{
					await UpdatePrices();
					await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error updating prices");
				}
			}
		}
		private async Task UpdatePrices()
		{
			var cryptocurrencies = await _cryptoService.GetActiveCryptocurrencies();
			foreach (var crypto in cryptocurrencies)
			{
				await _cryptoService.UpdatePrice(crypto.Symbol);
			}
		}
	}
}