using CryptoWallet.BackgroundJobs;
using PSS.DHPM.CryptoWallet.BackgroundJobs.Workers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

namespace PSS.DHPM.CryptoWallet.BackgroundJobs
{

	// Program.cs (para el Worker Service)
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					services.AddHostedService<PriceUpdateWorker>();
					services.AddHostedService<AlertCheckWorker>();

					services.AddScoped<ICryptoService, CryptoService>();
					services.AddScoped<IAlertService, AlertService>();

					services.AddDbContext<CryptoWalletContext>(options =>
						options.UseSqlServer(
							hostContext.Configuration.GetConnectionString("DefaultConnection")));
				});
	}
}