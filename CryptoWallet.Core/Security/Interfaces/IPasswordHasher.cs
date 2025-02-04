﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DHPM.CryptoWallet.Core.Security.Interfaces
{
	public interface IPasswordHasher
	{
		string HashPassword(string password);
		bool VerifyPassword(string password, string hashedPassword);
	}
}