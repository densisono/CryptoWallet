﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Infrastructure.ExternalApis.Models
{
	public class BinanceModels
	{
		public DateTime OpenTime
		{
			get; set;
		}
		public decimal Open
		{
			get; set;
		}
		public decimal High
		{
			get; set;
		}
		public decimal Low
		{
			get; set;
		}
		public decimal Close
		{
			get; set;
		}
		public decimal Volume
		{
			get; set;
		}
	}
}
