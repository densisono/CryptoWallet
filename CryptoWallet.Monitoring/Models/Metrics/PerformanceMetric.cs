using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Monitoring.Models.Metrics
{
	public class PerformanceMetric
	{
		public string MetricName
		{
			get; set;
		}
		public double Value
		{
			get; set;
		}
		public DateTime Timestamp
		{
			get; set;
		}
		public Dictionary<string, string> Tags
		{
			get; set;
		}
	}
}