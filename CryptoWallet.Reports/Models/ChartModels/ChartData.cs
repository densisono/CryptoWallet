using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Reports.Models.ChartModels
{
	public class ChartData
	{
		public string ChartType
		{
			get; set;
		}
		public List<string> Labels
		{
			get; set;
		}
		public List<ChartDataset> Datasets
		{
			get; set;
		}
	}
	public class ChartDataset
	{
		public string Label
		{
			get; set;
		}
		public List<decimal> Data
		{
			get; set;
		}
		public string BorderColor
		{
			get; set;
		}
		public bool Fill
		{
			get; set;
		}
	}
}