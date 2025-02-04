#region Using
#region Microsoft
#region Data
#region SqlClient
//using Microsoft.Data.SqlClient;
#endregion
#endregion
#endregion

#region System
using System;

#region Collections
#region Generic
using System.Collections.Generic;
#endregion
#endregion

#region Data
using System.Data;

#region SqlClient
using System.Data.SqlClient;
#endregion
#endregion
#endregion
#endregion

#region Namespace
#region PSS
#region DHPM
#region CryptoWallets
#region DataLayer
#region Tables
namespace PSS.DHPM.CryptoWallets.DataLayer.Tables
{
	#region Class
	#region Transactions
	public class Transactions
	{
		#region Functions
		#region DataTable
		#region Tabla
		#region ()
		public static DataTable Tabla()
		{
			return Tabla(CadenaSelect);
		}
		#endregion

		#region (string sel)
		public static DataTable Tabla(string sel)
		{
			SqlDataAdapter da;
			DataTable dt = new DataTable("Transactions");

			try
			{
				da = new SqlDataAdapter(sel, CadenaConexion);
				da.Fill(dt);
			}

			catch
			{
				return null;
			}

			return dt;
		}
		#endregion
		#endregion
		#endregion

		#region List
		#region <Transactions>
		#region TablaCol
		#region (string sel)
		public static List<Transactions> TablaCol(string sel)
		{
			List<Transactions> col = new List<Transactions>();

			using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
				SqlCommand cmd = new SqlCommand();
				SqlDataReader reader;
				cmd.CommandType = CommandType.Text;
				cmd.Connection = con;
				cmd.CommandText = sel;

				try
				{
					con.Open();
					reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Transactions r = Reader2Tipo(reader);
						col.Add(r);
					}

					reader.Close();
					con.Close();
				}

				catch (Exception ex)
				{
					return col;
				}

				finally
				{
					if (!(con == null))
					{
						con.Close();
					}
				}
			}

			return col;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region String
		#region Actualizar
		#region ()
		public string Actualizar()
		{
			string sel = "SELECT * FROM Transactions WHERE TransactionID = " + this.TransactionID.ToString();
			return Actualizar(sel);
		}
		#endregion

		#region (String sel)
		public string Actualizar(string sel)
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("Transactions");
			cnn = new SqlConnection(CadenaConexion);
			//da = new SqlDataAdapter(CadenaSelect, cnn);
			da = new SqlDataAdapter(sel, cnn);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.UpdateCommand = cb.GetUpdateCommand();
			//string sCommand;
			//sCommand = "UPDATE Transactions SET WalletID = @WalletID, CryptoID = @CryptoID, Amount = @Amount, TransactionDate = @TransactionDate, Notes = @Notes  WHERE (TransactionID = @TransactionID)";
			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
			//da.UpdateCommand.Parameters.AddWithValue("@TransactionID", TransactionID);
			//da.UpdateCommand.Parameters.AddWithValue("@WalletID", WalletID);
			//da.UpdateCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
			//da.UpdateCommand.Parameters.AddWithValue("@Amount", Amount);
			//da.UpdateCommand.Parameters.AddWithValue("@TransactionDate", TransactionDate);
			////da.UpdateCommand.Parameters.AddWithValue("@Notes", Notes);
			//da.UpdateCommand.Parameters.AddWithValue("@Notes", Notes);

			try
			{
				da.Fill(dt);
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}

			if (dt.Rows.Count == 0)
			{
				return Crear();
			}

			else
			{
				Transactions2Row(this, dt.Rows[0]);
			}

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Actualizado correctamente";
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}
		}
		#endregion
		#endregion

		#region AjustarAncho
		#region (string cadena, int ancho)
		private string ajustarAncho(string cadena, int ancho)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
			return (cadena + sb.ToString()).Substring(0, ancho).Trim();
		}
		#endregion
		#endregion

		#region Borrar
		#region ()
		public string Borrar()
		{
			string where = "TransactionID = " + this.TransactionID.ToString();
			return Borrar(where);
		}
		#endregion

		#region (String where)
		public string Borrar(string where)
		{
			string msg = "";
			string sCon = CadenaConexion;
			string sel = "DELETE FROM Transactions WHERE " + where;

			using (SqlConnection con = new SqlConnection(sCon))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand();
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = con;
					//cmd.CommandText = "BorrarTransactions";
					cmd.CommandText = sel;
					con.Open();
					tran = con.BeginTransaction();
					cmd.Transaction = tran;
					cmd.ExecuteNonQuery();
					tran.Commit();
					msg = "Eliminado correctamente los registros con : " + where + ".";
				}

				catch (Exception ex)
				{
					msg = "ERROR al eliminar los registros con : " + where + "." + ex.Message;

					try
					{
						tran.Rollback();
					}

					catch (Exception ex2)
					{
						msg = $"ERROR RollBack: {ex2.Message})";
					}

					finally
					{
						if (!(con == null))
						{
							con.Close();
						}
					}
				}
			}

			return msg;
		}
		#endregion
		#endregion

		#region Crear
		#region ()
		public string Crear()
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("Transactions");
			cnn = new SqlConnection(CadenaConexion);
			da = new SqlDataAdapter(CadenaSelect, cnn);
			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.InsertCommand = cb.GetInsertCommand();
			//string sCommand;
			//sCommand = "INSERT INTO Transactions (WalletID, CryptoID, Amount, TransactionDate, Notes)  VALUES(@WalletID, @CryptoID, @Amount, @TransactionDate, @Notes)";
			//da.InsertCommand = new SqlCommand(sCommand, cnn);
			//da.InsertCommand.Parameters.AddWithValue("@TransactionID", TransactionID);
			//da.InsertCommand.Parameters.AddWithValue("@WalletID", WalletID);
			//da.InsertCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
			//da.InsertCommand.Parameters.AddWithValue("@Amount", Amount);
			//da.InsertCommand.Parameters.AddWithValue("@TransactionDate", TransactionDate);
			//// TODO: Este campo seguramente es MEMO y el valor debería ser cero en lugar de 2147483647
			////da.InsertCommand.Parameters.AddWithValue("@Notes", Notes);
			//da.InsertCommand.Parameters.AddWithValue("@Notes", Notes);

			try
			{
				da.Fill(dt);
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}

			nuevoTransactions(dt, this);

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Se ha creado un nuevo Transactions";
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}
		}
		#endregion
		#endregion
		#endregion

		#region Transactions
		#region Buscar
		#region (string sWhere)
		public static Transactions Buscar(string sWhere)
		{
			Transactions o_Transactions = null;
			string sel = "SELECT * FROM Transactions WHERE " + sWhere;

			using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
				SqlCommand cmd = new SqlCommand();
				SqlDataReader reader;
				cmd.CommandType = CommandType.Text;
				cmd.Connection = con;
				cmd.CommandText = sel;

				try
				{
					con.Open();
					reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						o_Transactions = Reader2Tipo(reader);

						if (o_Transactions.TransactionID > 0)
						{
							break;
						}
					}

					reader.Close();
					con.Close();
				}

				catch (Exception ex)
				{
					return null;
				}

				finally
				{
					if (!(con == null))
					{
						con.Close();
					}
				}
			}

			return o_Transactions;
		}
		#endregion
		#endregion

		#region Reader2Tipo
		#region (SqlDataReader r)
		public static Transactions Reader2Tipo(SqlDataReader r)
		{
			Transactions o_Transactions = new Transactions();
			o_Transactions.TransactionID = ConversorTipos.Int32Data(r["TransactionID"].ToString());
			o_Transactions.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			o_Transactions.CryptoID = ConversorTipos.Int32Data(r["CryptoID"].ToString());
			o_Transactions.Amount = ConversorTipos.DecimalData(r["Amount"].ToString());
			o_Transactions.TransactionDate = ConversorTipos.DateTimeData(r["TransactionDate"].ToString());
			o_Transactions.Notes = r["Notes"].ToString();
			return o_Transactions;
		}
		#endregion
		#endregion

		#region Row2Tipo
		#region (DataRow r)
		public static Transactions Row2Tipo(DataRow r)
		{
			Transactions o_Transactions = new Transactions();
			o_Transactions.TransactionID = ConversorTipos.Int32Data(r["TransactionID"].ToString());
			o_Transactions.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			o_Transactions.CryptoID = ConversorTipos.Int32Data(r["CryptoID"].ToString());
			o_Transactions.Amount = ConversorTipos.DecimalData(r["Amount"].ToString());
			o_Transactions.TransactionDate = ConversorTipos.DateTimeData(r["TransactionDate"].ToString());
			o_Transactions.Notes = r["Notes"].ToString();
			return o_Transactions;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Methods
		#region Constructors
		#region Transactions
		#region ()
		public Transactions()
		{
		}
		#endregion

		#region (string conex)
		public Transactions(string conex)
		{
			CadenaConexion = conex;
		}
		#endregion
		#endregion
		#endregion

		#region Transactions2Row
		#region (Transactions o_Transactions, DataRow r)
		private static void Transactions2Row(Transactions o_Transactions, DataRow r)
		{
			//r["TransactionID"] = o_Transactions.TransactionID;
			r["WalletID"] = o_Transactions.WalletID;
			r["CryptoID"] = o_Transactions.CryptoID;
			r["Amount"] = o_Transactions.Amount;
			r["TransactionDate"] = o_Transactions.TransactionDate;
			r["Notes"] = o_Transactions.Notes;
		}
		#endregion
		#endregion

		#region NuevoTransactions
		#region (DataTable dt, Transactions o_Transactions)
		private static void nuevoTransactions(DataTable dt, Transactions o_Transactions)
		{
			DataRow dr = dt.NewRow();
			Transactions o_T = Row2Tipo(dr);
			o_T.TransactionID = o_Transactions.TransactionID;
			o_T.WalletID = o_Transactions.WalletID;
			o_T.CryptoID = o_Transactions.CryptoID;
			o_T.Amount = o_Transactions.Amount;
			o_T.TransactionDate = o_Transactions.TransactionDate;
			o_T.Notes = o_Transactions.Notes;
			Transactions2Row(o_T, dr);
			dt.Rows.Add(dr);
		}
		#endregion
		#endregion
		#endregion

		#region Properties
		#region String
		#region This
		#region [int index]
		public string this[int index]
		{
			get
			{
				if (index == 0)
				{
					return this.TransactionID.ToString();
				}

				else if (index == 1)
				{
					return this.WalletID.ToString();
				}

				else if (index == 2)
				{
					return this.CryptoID.ToString();
				}

				else if (index == 3)
				{
					return this.Amount.ToString();
				}

				else if (index == 4)
				{
					return this.TransactionDate.ToString();
				}

				else if (index == 5)
				{
					return this.Notes.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == 0)
				{
					this.TransactionID = ConversorTipos.Int32Data(value);
				}

				else if (index == 1)
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}

				else if (index == 2)
				{
					this.CryptoID = ConversorTipos.Int32Data(value);
				}

				else if (index == 3)
				{
					this.Amount = ConversorTipos.DecimalData(value);
				}

				else if (index == 4)
				{
					this.TransactionDate = ConversorTipos.DateTimeData(value);
				}

				else if (index == 5)
				{
					this.Notes = value;
				}
			}
		}
		#endregion

		#region [string index]
		public string this[string index]
		{
			get
			{
				if (index == "TransactionID")
				{
					return this.TransactionID.ToString();
				}

				else if (index == "WalletID")
				{
					return this.WalletID.ToString();
				}

				else if (index == "CryptoID")
				{
					return this.CryptoID.ToString();
				}

				else if (index == "Amount")
				{
					return this.Amount.ToString();
				}

				else if (index == "TransactionDate")
				{
					return this.TransactionDate.ToString();
				}

				else if (index == "Notes")
				{
					return this.Notes.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == "TransactionID")
				{
					this.TransactionID = ConversorTipos.Int32Data(value);
				}

				else if (index == "WalletID")
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}

				else if (index == "CryptoID")
				{
					this.CryptoID = ConversorTipos.Int32Data(value);
				}

				else if (index == "Amount")
				{
					this.Amount = ConversorTipos.DecimalData(value);
				}

				else if (index == "TransactionDate")
				{
					this.TransactionDate = ConversorTipos.DateTimeData(value);
				}

				else if (index == "Notes")
				{
					this.Notes = value;
				}
			}
		}
		#endregion
		#endregion
		#endregion

		#region System
		#region DateTime
		#region TransactionDate
		public System.DateTime TransactionDate
		{
			get
			{
				return m_TransactionDate;
			}

			set
			{
				m_TransactionDate = value;
			}
		}
		#endregion
		#endregion

		#region Decimal
		#region Amount
		public System.Decimal Amount
		{
			get
			{
				return m_Amount;
			}

			set
			{
				m_Amount = value;
			}
		}
		#endregion
		#endregion

		#region Int32
		#region CryptoID
		public System.Int32 CryptoID
		{
			get
			{
				return m_CryptoID;
			}

			set
			{
				m_CryptoID = value;
			}
		}
		#endregion

		#region TransactionID
		public System.Int32 TransactionID
		{
			get
			{
				return m_TransactionID;
			}

			set
			{
				m_TransactionID = value;
			}
		}
		#endregion

		#region WalletID
		public System.Int32 WalletID
		{
			get
			{
				return m_WalletID;
			}

			set
			{
				m_WalletID = value;
			}
		}
		#endregion
		#endregion

		#region String
		#region Notes
		public System.String Notes
		{
			get
			{
				return m_Notes;
			}

			set
			{
				m_Notes = value;
			}
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Variables
		#region String
		public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM Transactions";
		#endregion

		#region System
		#region DateTime
		private System.DateTime m_TransactionDate;
		#endregion

		#region Decimal
		private System.Decimal m_Amount;
		#endregion

		#region Int32
		private System.Int32 m_CryptoID;
		private System.Int32 m_TransactionID;
		private System.Int32 m_WalletID;
		#endregion

		#region String
		private System.String m_Notes;
		#endregion
		#endregion
		#endregion
	}
	#endregion
	#endregion
}
#endregion
#endregion
#endregion
#endregion
#endregion
#endregion