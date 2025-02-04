using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Core.Security.Models
{
	public class EncryptionResult
	{
		public byte[] CipherText
		{
			get; set;
		}
		public byte[] Nonce
		{
			get; set;
		}
		public byte[] Tag
		{
			get; set;
		}
	}
}
