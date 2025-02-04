using System.Configuration;
using PSS.DHPM.CryptoWallet.Desktop.Forms;
using PSS.DHPM.CryptoWallet.Desktop.Services;

namespace CryptoWallet.Desktop
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var services = new ServiceCollection();
			ConfigureServices(services);
			using (var serviceProvider = services.BuildServiceProvider())
			{
				var mainForm = serviceProvider.GetRequiredService<MainForm>();
				Application.Run(mainForm);
			}
		}
		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IApiService, ApiService>();
			services.AddScoped<MainForm>();
			var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
			services.AddSingleton<IConfiguration>(configuration);
		}
	}
}