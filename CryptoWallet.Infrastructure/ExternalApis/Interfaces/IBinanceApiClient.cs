using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Interfaces
{
	public interface IBinanceApiClient
	{
		Task<decimal> GetCurrentPrice(string symbol);
		Task<IEnumerable<CandleStick>> GetKlines(string symbol, string interval, DateTime startTime, DateTime endTime);
	}
}
