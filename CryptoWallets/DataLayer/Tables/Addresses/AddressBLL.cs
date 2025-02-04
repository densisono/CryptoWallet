using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Model = PSS.DHPM.CryptoWallets.DataLayer.Tables.Addresses.Models;
using PSS.DHPM.CryptoWallets.DataLayer;
using System.Data.SqlClient;
namespace PSS.DHPM.CryptoWallets.DataLayer.Tables.Addresses.BusinessLayer
{
	public class AddressBLL
	{
		private readonly AddressDAL _addressDAL;
		private static readonly string EncryptionKey = "myencryptionkey123";
		public AddressBLL(string connectionString)
		{
			_addressDAL = new AddressDAL(connectionString);
		}
		public Model.Addressesv3 GetAddressById(int id)
		{
			return _addressDAL.GetById(id);
		}
		public void CreateAddress(Model.Addressesv3 address)
		{
			address.PrivateKey = EncryptPrivateKey(address.PrivateKey);
			_addressDAL.Crear(address);
		}
		public string UpdateAddress(string sel, List<SqlParameter> parameters)
		{
			return _addressDAL.Actualizar(sel, parameters);
		}
		public string DeleteAddress(string columnName, List<SqlParameter> parameters)
		{
			return _addressDAL.Borrar(columnName, parameters);
		}
		public static string EncryptPrivateKey(byte[] privateKey)
		{
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
				aes.IV = new byte[16]; // 16 bytes de ceros para simplificar
				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
				byte[] encrypted = encryptor.TransformFinalBlock(privateKey, 0, privateKey.Length);
				return Convert.ToBase64String(encrypted);
			}
		}
		public static byte[] DecryptPrivateKey(string encryptedPrivateKey)
		{
			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
				aes.IV = new byte[16];
				ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
				return decryptor.TransformFinalBlock(Convert.FromBase64String(encryptedPrivateKey), 0, Convert.FromBase64String(encryptedPrivateKey).Length);
			}
		}
		private static void Addresses2Row(Model.Addressesv3 address, DataRow r)
		{
			r["AddressID"] = address.AddressID;
			r["WalletID"] = address.WalletID;
			r["PublicKey"] = address.PublicKey;
			r["PrivateKey"] = Convert.ToBase64String(address.PrivateKey);
		}
		private static void nuevoAddresses(DataTable dt, Model.Addressesv3 address)
		{
			DataRow r = dt.NewRow();
			Addresses2Row(address, r);
			dt.Rows.Add(r);
		}
	}
}