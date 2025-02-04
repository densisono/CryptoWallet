using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.DHPM.CryptoWallet.Core.Domain.Entities;

namespace PSS.DHPM.CryptoWallet.Core.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
        IRepository<User> Users
        {
            get;
        }
        IRepository<Wallet> Wallets
        {
            get;
        }
        IRepository<WalletAddress> WalletAddresses
        {
            get;
        }
        Task<int> SaveChangesAsync();
	}
}