using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Infrastructure.Data.Context
{
    public class CryptoWalletContext : DbContext
    {
        public CryptoWalletContext(DbContextOptions<CryptoWalletContext> options) : base(options)
        {
        }
        public DbSet<User> Users
        {
            get;
            set;
        }
        public DbSet<UserProfile> UserProfiles
        {
            get;
            set;
        }
        public DbSet<Wallet> Wallets
        {
            get;
            set;
        }
        public DbSet<WalletType> WalletTypes
        {
            get;
            set;
        }
        public DbSet<WalletAddresses> WalletAddresses
        {
            get;
            set;
        }
        public DbSet<CryptoCurrency> CryptoCurrencies
        {
            get;
            set;
        }
        public DbSet<FiatCurrency> FiatCurrencies
        {
            get;
            set;
        }
        public DbSet<PriceHistory> PriceHistory
        {
            get;
            set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("crypto");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
	}
}