using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PSS.DHPM.CryptoWallet.Core.Security.Interfaces;
using PSS.DHPM.CryptoWallet.Core.Security.Models;

namespace PSS.DHPM.CryptoWallet.Infrastructure.Security.Services
{
	public class EncryptionService : IEncryptionService
	{
		private readonly byte[] _key;
		private const int NonceSize = 12;
		private const int TagSize = 16;
		private readonly IConfiguration _configuration;
		public EncryptionService(IConfiguration configuration)
		{
			_configuration = configuration;
			_key = Convert.FromBase64String(configuration["Encryption:Key"]);
		}
		public async Task<EncryptionResult> EncryptAsync(string plainText, string? additionalAuthenticatedData = null)
		{
			using var aes = new AesGcm(_key);
			var nonce = new byte[NonceSize];
			var tag = new byte[TagSize];

			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(nonce);
			}

			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			var cipherText = new byte[plainTextBytes.Length];

			var aad = additionalAuthenticatedData != null ?
				Encoding.UTF8.GetBytes(additionalAuthenticatedData) : null;

			aes.Encrypt(nonce, plainTextBytes, cipherText, tag, aad);

			return new EncryptionResult
			{
				CipherText = cipherText,
				Nonce = nonce,
				Tag = tag
			};
		}
		public async Task<string> DecryptAsync(byte[] cipherText, byte[] nonce, byte[] tag,
		string? additionalAuthenticatedData = null)
		{
			using var aes = new AesGcm(_key);
			var plainText = new byte[cipherText.Length];

			var aad = additionalAuthenticatedData != null ?
				Encoding.UTF8.GetBytes(additionalAuthenticatedData) : null;

			aes.Decrypt(nonce, cipherText, tag, plainText, aad);

			return Encoding.UTF8.GetString(plainText);
		}
		public async Task<string> EncryptRecoveryPhrase(string recoveryPhrase, int userId)
		{
			var result = await EncryptAsync(recoveryPhrase, userId.ToString());
			return Convert.ToBase64String(result.CipherText) + "." +
				   Convert.ToBase64String(result.Nonce) + "." +
				   Convert.ToBase64String(result.Tag);
		}
		public async Task<string> DecryptRecoveryPhrase(string encryptedPhrase, int userId)
		{
			var parts = encryptedPhrase.Split('.');
			if (parts.Length != 3)
				throw new ArgumentException("Invalid encrypted phrase format");

			var cipherText = Convert.FromBase64String(parts[0]);
			var nonce = Convert.FromBase64String(parts[1]);
			var tag = Convert.FromBase64String(parts[2]);

			return await DecryptAsync(cipherText, nonce, tag, userId.ToString());
		}
	}
}
