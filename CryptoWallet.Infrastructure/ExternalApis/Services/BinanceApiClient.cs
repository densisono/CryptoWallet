using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Interfaces;

namespace PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Services
{
	public class BinanceApiClient : IBinanceApiClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;
		private readonly string _apiSecret;
		public BinanceApiClient(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiKey = configuration["BinanceApi:ApiKey"];
			_apiSecret = configuration["BinanceApi:ApiSecret"];

			_httpClient.BaseAddress = new Uri("https://api.binance.com");
			_httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", _apiKey);
		}
		public async Task<decimal> GetCurrentPrice(string symbol)
		{
			var response = await _httpClient.GetAsync($"/api/v3/ticker/price?symbol={symbol}");
			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			var price = JsonSerializer.Deserialize<BinanceTickerPrice>(content);
			return price.Price;
		}
		public async Task<IEnumerable<CandleStick>> GetKlines(string symbol, string interval,
		DateTime startTime, DateTime endTime)
		{
			var startTimestamp = ((DateTimeOffset)startTime).ToUnixTimeMilliseconds();
			var endTimestamp = ((DateTimeOffset)endTime).ToUnixTimeMilliseconds();

			var response = await _httpClient.GetAsync(
				$"/api/v3/klines?symbol={symbol}&interval={interval}" +
				$"&startTime={startTimestamp}&endTime={endTimestamp}");

			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			var klines = JsonSerializer.Deserialize<List<List<object>>>(content);

			return klines.Select(k => new CandleStick
			{
				OpenTime = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(k[0])).DateTime,
				Open = Convert.ToDecimal(k[1]),
				High = Convert.ToDecimal(k[2]),
				Low = Convert.ToDecimal(k[3]),
				Close = Convert.ToDecimal(k[4]),
				Volume = Convert.ToDecimal(k[5])
			});
		}
	}
}