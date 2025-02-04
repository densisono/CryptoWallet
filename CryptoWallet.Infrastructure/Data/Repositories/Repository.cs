﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.DHPM.CryptoWallet.Core.Domain.Interfaces;
using PSS.DHPM.CryptoWallet.Infrastructure.Data.Context;

namespace PSS.DHPM.CryptoWallet.Infrastructure.Data.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected readonly CryptoWalletContext _context;
		protected readonly DbSet<T> _dbSet;
		public Repository(CryptoWalletContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}
		public async Task<T?> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}
		public async Task<T> AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			return entity;
		}
		public Task UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			return Task.CompletedTask;
		}
		public Task DeleteAsync(T entity)
		{
			_dbSet.Remove(entity);
			return Task.CompletedTask;
		}
	}
}