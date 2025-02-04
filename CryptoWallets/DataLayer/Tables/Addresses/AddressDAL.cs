using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model = PSS.DHPM.CryptoWallets.DataLayer.Tables.Addresses.Models;
namespace PSS.DHPM.CryptoWallets.DataLayer
{
	public class AddressDAL
	{
		private readonly string connectionString = ConfigManager.GetConnectionString();
		public AddressDAL(string connString)
		{
			this.connectionString = connString;
		}
		public Model.Addressesv3 GetById(int addressId)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query = "SELECT * FROM Addresses WHERE AddressID = @AddressID";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@AddressID", addressId);
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							return new Model.Addressesv3
							{
								AddressID = Convert.ToInt32(reader["AddressID"]),
								WalletID = Convert.ToInt32(reader["WalletID"]),
								PublicKey = reader["PublicKey"].ToString(),
								PrivateKey = Convert.FromBase64String(reader["PrivateKey"].ToString())
							};
						}
					}
				}
			}
			return null;
		}
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
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@value", value);
					conn.Open();
					using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();
						adapter.Fill(dt);
						return dt;
					}
				}
			}
		}
		public DataTable Tabla(string sel, List<SqlParameter> parameters)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(sel, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters.ToArray());
					}
					conn.Open();
					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();
						da.Fill(dt);
						return dt;
					}
				}
			}
		}
		public string Actualizar(string sel, List<SqlParameter> parameters)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(sel, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters.ToArray());
					}
					conn.Open();
					int rowsAffected = cmd.ExecuteNonQuery();
					return rowsAffected > 0 ? "Update successful" : "Update failed";
				}
			}
		}
		public string Borrar(string columnName, List<SqlParameter> parameters)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query = $"DELETE FROM Addresses WHERE {columnName} = @Value";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters.ToArray());
					}
					conn.Open();
					int rowsAffected = cmd.ExecuteNonQuery();
					return rowsAffected > 0 ? "Delete successful" : "Delete failed";
				}
			}
		}
		public string Crear(Model.Addressesv3 address)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query = "INSERT INTO Addresses (WalletID, PublicKey, PrivateKey) VALUES (@WalletID, @PublicKey, @PrivateKey)";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@WalletID", address.WalletID);
					cmd.Parameters.AddWithValue("@PublicKey", address.PublicKey);
					cmd.Parameters.AddWithValue("@PrivateKey", Convert.ToBase64String(address.PrivateKey));
					conn.Open();
					int rowsAffected = cmd.ExecuteNonQuery();
					return rowsAffected > 0 ? "Insert successful" : "Insert failed";
				}
			}
		}
		public static Model.Addressesv3 Reader2Tipo(SqlDataReader r)
		{
			return new Model.Addressesv3
			{
				AddressID = Convert.ToInt32(r["AddressID"]),
				WalletID = Convert.ToInt32(r["WalletID"]),
				PublicKey = r["PublicKey"].ToString(),
				PrivateKey = Convert.FromBase64String(r["PrivateKey"].ToString())
			};
		}
	}
}