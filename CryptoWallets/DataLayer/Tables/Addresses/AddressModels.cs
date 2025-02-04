using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PSS.DHPM.CryptoWallets.DataLayer.Tables.Addresses.Models
{
	public class Addressesv3
	{
		public int AddressID
		{
			get;
			set;
		}
		public int WalletID
		{
			get;
			set;
		}
		public string PublicKey
		{
			get;
			set;
		}
		public byte[] PrivateKey
		{
			get;
			set;
		}
	}
}  // En formato encriptado