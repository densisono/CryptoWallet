using PSS.DHPM.CryptoWallet.Monitoring.Models.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Monitoring.Services
{
	public class PerformanceMonitor : IPerformanceMonitor
	{
		private readonly ILogger<PerformanceMonitor> _logger;
		private readonly IMetricsRepository _metricsRepository;
		private readonly IAlertService _alertService;
		public PerformanceMonitor(ILogger<PerformanceMonitor> logger, IMetricsRepository metricsRepository, IAlertService alertService)
		{
			_logger = logger;
			_metricsRepository = metricsRepository;
			_alertService = alertService;
		}
		public async Task RecordMetricAsync(PerformanceMetric metric)
		{
			await _metricsRepository.SaveMetricAsync(metric);
			await CheckAlertRules(metric);
		}
		private async Task CheckAlertRules(PerformanceMetric metric)
		{
			var rules = await _metricsRepository.GetAlertRulesAsync(metric.MetricName);
			foreach (var rule in rules)
			{
				if (ShouldTriggerAlert(metric, rule))
				{
					await _alertService.TriggerAlertAsync(rule, metric);
				}
			}
		}
	}
}