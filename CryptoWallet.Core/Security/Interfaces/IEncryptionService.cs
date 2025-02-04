using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.DHPM.CryptoWallet.Core.Security.Models;

namespace PSS.DHPM.CryptoWallet.Core.Security.Interfaces
{
	public interface IEncryptionService
	{
		Task<EncryptionResult> EncryptAsync(string plainText, string? additionalAuthenticatedData = null);
		Task<string> DecryptAsync(byte[] cipherText, byte[] nonce, byte[] tag, string? additionalAuthenticatedData = null);
		Task<string> EncryptRecoveryPhrase(string recoveryPhrase, int userId);
		Task<string> DecryptRecoveryPhrase(string encryptedPhrase, int userId);
	}
}