using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.DHPM.CryptoWallet.Core.Domain.Common;

namespace PSS.DHPM.CryptoWallet.Core.Domain.Entities
{
	public class User:BaseEntity
	{
        public int UserId
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        } = string.Empty;
        public string Email
        {
            get;
            set;
        } = string.Empty;
        public string PasswordHash
        {
            get;
            set;
        } = string.Empty;
        public bool TwoFactorEnabled
        {
            get;
            set;
        }
        public DateTime? LastLogin
        {
            get;
            set;
        }
        public UserProfile? Profile
        {
            get;
            set;
        }
        public ICollection<Wallet> Wallets
        {
            get;
            set;
        } = new List<Wallet>();
	}
}