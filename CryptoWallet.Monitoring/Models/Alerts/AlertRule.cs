using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Monitoring.Models.Alerts
{
	public class AlertRule
	{
		public int RuleId
		{
			get; set;
		}
		public string MetricName
		{
			get; set;
		}
		public string Condition
		{
			get; set;
		}
		public double Threshold
		{
			get; set;
		}
		public string NotificationChannel
		{
			get; set;
		}
	}
}