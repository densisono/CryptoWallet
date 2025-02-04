using System;
using System.Security.Cryptography;
using System.Text;
namespace PSS.DHPM.CryptoWallets.DataLayer
{
	public static class CryptoHelper
	{
		public static string Encrypt(string text, string masterKey)
		{
			using var aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes(masterKey.PadRight(32).Substring(0, 32)); // Ajustar clave a 32 bytes
			aes.IV = new byte[16]; // IV de 16 bytes en ceros
			using var encryptor = aes.CreateEncryptor();
			byte[] buffer = Encoding.UTF8.GetBytes(text);
			return Convert.ToBase64String(encryptor.TransformFinalBlock(buffer, 0, buffer.Length));
		}
	}
}