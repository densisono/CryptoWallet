using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace PSS.DHPM.CryptoWallet.Desktop.Services
{
	public class ApiService : IApiService
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseUrl;
		private string _token;
		public ApiService(IConfiguration configuration)
		{
			_httpClient = new HttpClient();
			_baseUrl = configuration["ApiSettings:BaseUrl"];
		}
		public void SetToken(string token)
		{
			_token = token;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}
		public async Task<IEnumerable<WalletDto>> GetWalletsAsync()
		{
			var response = await _httpClient.GetAsync($"{_baseUrl}/api/wallets");
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<IEnumerable<WalletDto>>(content);
		}
	}
}