using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.DHPM.CryptoWallet.Core.Domain.Entities;
using PSS.DHPM.CryptoWallet.Core.Domain.Interfaces;
using PSS.DHPM.CryptoWallet.Infrastructure.Data.Context;

namespace PSS.DHPM.CryptoWallet.Infrastructure.Data.Repositories
{
	public class UnitOfWork
	{
		private readonly CryptoWalletContext _context;
		private IRepository<User>? _userRepository;
		private IRepository<Wallet>? _walletRepository;
		private IRepository<WalletAddress>? _walletAddressRepository;
		public UnitOfWork(CryptoWalletContext context)
		{
			_context = context;
		}
		public IRepository<User> Users => _userRepository ??= new Repository<User>(_context);
		public IRepository<Wallet> Wallets => _walletRepository ??= new Repository<Wallet>(_context);
		public IRepository<WalletAddress> WalletAddresses => _walletAddressRepository ??= new Repository<WalletAddress>(_context);
		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}
		public void Dispose()
		{
			_context.Dispose();
		}
	}
}