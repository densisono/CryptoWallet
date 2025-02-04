using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Security.Cryptography;
namespace PSS.DHPM.CryptoWallets.DataLayer
{
	public static class ConfigManager
	{
		public static IConfigurationRoot GetConfiguration()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
			return builder.Build();
		}
		public static string GetConnectionString()
		{
			return GetConfiguration().GetConnectionString("DefaultConnection");
		}
		private static IConfigurationRoot configuration;
		static ConfigManager()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
			configuration = builder.Build();
		}
		public static string GetEncryptedKey()
		{
			return configuration["Encryption:EncryptedKey"];
		}
		public static string DecryptKey(string encryptedKey, string masterKey)
		{
			using var aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes(masterKey.PadRight(32).Substring(0, 32));
			aes.IV = new byte[16]; // Vector de inicialización (IV) en ceros
			using var decryptor = aes.CreateDecryptor();
			byte[] buffer = Convert.FromBase64String(encryptedKey);
			return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(buffer, 0, buffer.Length));
		}
	}
}