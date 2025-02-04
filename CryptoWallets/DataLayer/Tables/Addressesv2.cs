using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace PSS.DHPM.CryptoWallets.DataLayer.Tables
{
	public class Addressesv2
	{
		private static readonly string EncryptionKey = "myencryptionkey123"; /* Clave De Encriptación */

		//public static Addressesv2 Buscar(string sWhere)
		//{
		//	Addressesv2 o_Addresses = null;
		//	string sel = "SELECT * FROM Addresses WHERE " + sWhere;

		//	using (SqlConnection con = new SqlConnection(CadenaConexion))
		//	{
		//		SqlCommand cmd = new SqlCommand(sel, con);

		//		try
		//		{
		//			con.Open();
		//			SqlDataReader reader = cmd.ExecuteReader();

		//			if (reader.Read())
		//			{
		//				o_Addresses = Reader2Tipo(reader);
		//			}

		//			reader.Close();
		//		}

		//		catch (Exception ex)
		//		{
		//			/* Log Or Handle Exception */
		//			return null;
		//		}
		//	}

		//	return o_Addresses;
		//}

		public DataTable Buscar(string columnName, string value)
		{
			// Validar que el nombre de la columna es seguro (evita inyección en `columnName`)
			HashSet<string> columnasValidas = new HashSet<string>
			{
				"AddressID",
				"WalletID",
				"PublicKey",
				"PrivateKey"
			}; /* Reemplazar Con Columnas Reales */

			if (!columnasValidas.Contains(columnName))
			{
				throw new ArgumentException("ERROR: Nombre de columna inválido.");
			}

			string query = $"SELECT * FROM Addresses WHERE {columnName} = @value";

			using (SqlConnection conn = new SqlConnection(CadenaConexion))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@value", value);

					using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();
						adapter.Fill(dt);
						return dt;
					}
				}
			}
		}

		public static Addressesv2 Reader2Tipo(SqlDataReader r)
		{
			Addressesv2 o_Addresses = new Addressesv2
			{
				AddressID = ConversorTipos.Int32Data(r["AddressID"].ToString()),
				WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString()),
				PublicKey = r["PublicKey"].ToString(),
				PrivateKey = DecryptPrivateKey(r["PrivateKey"].ToString()) /* Desencriptar PrivateKey */
			};

			return o_Addresses;
		}

		public static string EncryptPrivateKey(byte[] privateKey)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
				aesAlg.IV = new byte[16]; /* Usamos Un IV De 16 bytes De Ceros (Para Simplificar) */
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				byte[] encrypted = encryptor.TransformFinalBlock(privateKey, 0, privateKey.Length);
				return Convert.ToBase64String(encrypted);
			}
		}

		public static byte[] DecryptPrivateKey(string encryptedPrivateKey)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
				aesAlg.IV = new byte[16]; /* Usamos Un IV De 16 bytes De Ceros */
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				byte[] encryptedBytes = Convert.FromBase64String(encryptedPrivateKey);
				return decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
			}
		}

		public static DataTable Tabla(string sel, List<SqlParameter> parameters)
		{
			using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
				SqlDataAdapter da = new SqlDataAdapter(sel, con);

				if (parameters != null)
				{
					foreach (var param in parameters)
					{
						da.SelectCommand.Parameters.Add(param);
					}
				}

				DataTable dt = new DataTable("Addresses");

				try
				{
					da.Fill(dt);
				}

				catch
				{
					/* Log Or Handle Exception */
					return null;
				}

				return dt;
			}
		}

		public string Actualizar()
		{
			string sel = "SELECT * FROM Addresses WHERE AddressID = @AddressID";

			List<SqlParameter> parameters = new List<SqlParameter>
			{
				new SqlParameter("@AddressID", SqlDbType.Int)
				{
					Value = this.AddressID
				}
			};

			return Actualizar(sel, parameters);
		}

		public string Actualizar(string sel, List<SqlParameter> parameters)
		{
			using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
				SqlDataAdapter da = new SqlDataAdapter(sel, con);
				DataTable dt = new DataTable("Addresses");
				da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
				SqlCommandBuilder cb = new SqlCommandBuilder(da);
				da.UpdateCommand = cb.GetUpdateCommand();

				if (parameters != null)
				{
					foreach (var param in parameters)
					{
						da.SelectCommand.Parameters.Add(param);
					}
				}

				try
				{
					da.Fill(dt);

					if (dt.Rows.Count == 0)
					{
						return Crear();
					}

					Addresses2Row(this, dt.Rows[0]);
					da.Update(dt);
					dt.AcceptChanges();
					return "Actualizado Correctamente";
				}

				catch (Exception ex)
				{
					return "ERROR: " + ex.Message;
				}
			}
		}

		private static void Addresses2Row(Addressesv2 o_Addresses, DataRow r)
		{
			r["WalletID"] = o_Addresses.WalletID;
			r["PublicKey"] = o_Addresses.PublicKey;
			r["PrivateKey"] = EncryptPrivateKey(o_Addresses.PrivateKey); /* Encriptar PrivateKey Antes De Guardar */
		}

		public string Borrar()
		{
			string where = "AddressID = @AddressID";

			List<SqlParameter> parameters = new List<SqlParameter>
			{
				new SqlParameter("@AddressID", SqlDbType.Int)
				{
					Value = this.AddressID
				}
			};

			return Borrar(where, parameters);
		}

		//public string Borrar(string where, List<SqlParameter> parameters)
		//{
		//	string msg = "";
		//	string sel = "DELETE FROM Addresses WHERE " + where;

		//	using (SqlConnection con = new SqlConnection(CadenaConexion))
		//	{
		//		SqlTransaction tran = null;

		//		try
		//		{
		//			SqlCommand cmd = new SqlCommand(sel, con);

		//			if (parameters != null)
		//			{
		//				foreach (var param in parameters)
		//				{
		//					cmd.Parameters.Add(param);
		//				}
		//			}

		//			con.Open();
		//			tran = con.BeginTransaction();
		//			cmd.Transaction = tran;
		//			cmd.ExecuteNonQuery();
		//			tran.Commit();
		//			msg = "Eliminado Correctamente Los Registros Con : " + where + ".";
		//		}

		//		catch (Exception ex)
		//		{
		//			msg = "ERROR Al Eliminar Los Registros Con : " + where + "." + ex.Message;

		//			try
		//			{
		//				tran.Rollback();
		//			}

		//			catch (Exception ex2)
		//			{
		//				msg = $"ERROR RollBack: {ex2.Message}";
		//			}
		//		}
		//	}

		//	return msg;
		//}

		public string Borrar(string columnName, List<SqlParameter> parameters)
		{
			string msg = "";
			/* Validar Que El Nombre De La Columna Es Seguro (Evita Inyección En 'where') */

			HashSet<string> columnasValidas = new HashSet<string>
			{
				"AddressID",
				"WalletID",
				"PublicKey",
				"PrivateKey"
			}; /* Reemplazar Con Columnas Reales */

			if (!columnasValidas.Contains(columnName))
			{
				return "ERROR: Nombre De Columna Inválido.";
			}

			string query = $"DELETE FROM Addresses WHERE {columnName} = @value";

			using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand(query, con);

					if (parameters != null && parameters.Count > 0)
					{
						cmd.Parameters.AddRange(parameters.ToArray());
					}

					else
					{
						return "ERROR: Parámetros Vacíos.";
					}

					con.Open();
					tran = con.BeginTransaction();
					cmd.Transaction = tran;
					cmd.ExecuteNonQuery();
					tran.Commit();
					msg = $"Eliminado Correctamente Los Registros Con {columnName}.";
				}

				catch (Exception ex)
				{
					msg = $"ERROR Al Eliminar Registros: {ex.Message}";

					try
					{
						tran?.Rollback();
					}

					catch (Exception ex2)
					{
						msg = $"ERROR En RollBack: {ex2.Message}";
					}
				}
			}

			return msg;
		}

		public string Crear()
		{
			using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
				SqlDataAdapter da = new SqlDataAdapter(CadenaSelect, con);
				DataTable dt = new DataTable("Addresses");
				da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
				SqlCommandBuilder cb = new SqlCommandBuilder(da);
				da.InsertCommand = cb.GetInsertCommand();
				
				try
				{
					da.Fill(dt);
					nuevoAddresses(dt, this);
					da.Update(dt);
					dt.AcceptChanges();
					return "Se Ha Creado Un Nuevo Addresses";
				}
				
				catch (Exception ex)
				{
					return "ERROR: " + ex.Message;
				}
			}
		}
		
		private static void nuevoAddresses(DataTable dt, Addressesv2 o_Addresses)
		{
			DataRow dr = dt.NewRow();
			Addresses2Row(o_Addresses, dr);
			dt.Rows.Add(dr);
		}
		
		public Addressesv2()
		{
		}
		
		public Addressesv2(string conex)
		{
			CadenaConexion = conex;
		}
		
		public System.Byte[] PrivateKey
		{
			get
			{
				return m_PrivateKey;
			}
			
			set
			{
				m_PrivateKey = value;
			}
		}
		
		public System.Int32 AddressID
		{
			get;
			set;
		}
		
		public System.Int32 WalletID
		{
			get;
			set;
		}
		
		public System.String PublicKey
		{
			get;
			set;
		}
		
		public static string CadenaConexion = @"Data Source=Localhost; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM Addresses";
		private System.Byte[] m_PrivateKey;
	}
}