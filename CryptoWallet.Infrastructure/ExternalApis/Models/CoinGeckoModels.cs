using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Models
{
	public class CoinGeckoModels
	{
		public decimal CurrentPrice
		{
			get; set;
		}
		public decimal MarketCap
		{
			get; set;
		}
		public decimal Volume24h
		{
			get; set;
		}
		public decimal PriceChangePercentage24h
		{
			get; set;
		}
	}
}