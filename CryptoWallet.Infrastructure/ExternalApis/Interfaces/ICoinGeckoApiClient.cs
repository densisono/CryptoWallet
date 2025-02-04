using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Interfaces
{
	public interface ICoinGeckoApiClient
	{
		Task<Dictionary<string, decimal>> GetPrices(IEnumerable<string> coinIds, string currency);
		Task<CoinMarketData> GetCoinMarketData(string coinId);
	}
}