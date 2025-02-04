using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Reports.Models.ReportModels
{
	public class PortfolioReport
	{
		public int UserId
		{
			get; set;
		}
		public DateTime ReportDate
		{
			get; set;
		}
		public List<PortfolioPosition> Positions
		{
			get; set;
		}
		public decimal TotalValue
		{
			get; set;
		}
		public decimal DailyProfitLoss
		{
			get; set;
		}
		public decimal TotalProfitLoss
		{
			get; set;
		}
	}
}