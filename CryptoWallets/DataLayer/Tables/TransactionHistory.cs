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

#region PSS
#region DHPM
#region CryptoWallets
#region DataLayer
#region Tables
namespace PSS.DHPM.CryptoWallets.DataLayer.Tables
{
	#region Class
	#region TransactionHistory
	public class TransactionHistory
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
			DataTable dt = new DataTable("TransactionHistory");

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
		#region <TransactionHistory> 
		#region TablaCol
		#region (string sel)
		public static List<TransactionHistory> TablaCol(string sel)
		{
			List<TransactionHistory> col = new List<TransactionHistory>();

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
						TransactionHistory r = Reader2Tipo(reader);
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
			string sel = "SELECT * FROM TransactionHistory WHERE HistoryID = " + this.HistoryID.ToString();
			return Actualizar(sel);
		}
		#endregion

		#region (string sel)
		public string Actualizar(string sel)
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("TransactionHistory");
			cnn = new SqlConnection(CadenaConexion);
			//da = new SqlDataAdapter(CadenaSelect, cnn);
			da = new SqlDataAdapter(sel, cnn);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.UpdateCommand = cb.GetUpdateCommand();
			//string sCommand;
			//sCommand = "UPDATE TransactionHistory SET TransactionID = @TransactionID, Status = @Status, Timestamp = @Timestamp  WHERE (HistoryID = @HistoryID)";
			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
			//da.UpdateCommand.Parameters.AddWithValue("@HistoryID", HistoryID);
			//da.UpdateCommand.Parameters.AddWithValue("@TransactionID", TransactionID);
			//da.UpdateCommand.Parameters.AddWithValue("@Status", Status);
			//da.UpdateCommand.Parameters.AddWithValue("@Timestamp", Timestamp);

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
				TransactionHistory2Row(this, dt.Rows[0]);
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
			string where = "HistoryID = " + this.HistoryID.ToString();
			return Borrar(where);
		}
		#endregion

		#region (string where)
		public string Borrar(string where)
		{
			string msg = "";
			string sCon = CadenaConexion;
			string sel = "DELETE FROM TransactionHistory WHERE " + where;

			using (SqlConnection con = new SqlConnection(sCon))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand();
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = con;
					//cmd.CommandText = "BorrarTransactionHistory";
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
			DataTable dt = new DataTable("TransactionHistory");
			cnn = new SqlConnection(CadenaConexion);
			da = new SqlDataAdapter(CadenaSelect, cnn);
			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.InsertCommand = cb.GetInsertCommand();
			//string sCommand;
			//sCommand = "INSERT INTO TransactionHistory (TransactionID, Status, Timestamp)  VALUES(@TransactionID, @Status, @Timestamp) ";
			//da.InsertCommand = new SqlCommand(sCommand, cnn);
			//da.InsertCommand.Parameters.AddWithValue("@HistoryID", HistoryID);
			//da.InsertCommand.Parameters.AddWithValue("@TransactionID", TransactionID);
			//da.InsertCommand.Parameters.AddWithValue("@Status", Status);
			//da.InsertCommand.Parameters.AddWithValue("@Timestamp", Timestamp);

			try
			{
				da.Fill(dt);
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}

			nuevoTransactionHistory(dt, this);

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Se ha creado un nuevo TransactionHistory";
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}
		}
		#endregion
		#endregion
		#endregion

		#region TransactionHistory
		#region Buscar
		#region (string sWhere)
		public static TransactionHistory Buscar(string sWhere)
		{
			TransactionHistory o_TransactionHistory = null;
			string sel = "SELECT * FROM TransactionHistory WHERE " + sWhere;

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
						o_TransactionHistory = Reader2Tipo(reader);

						if (o_TransactionHistory.HistoryID > 0)
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

			return o_TransactionHistory;
		}
		#endregion
		#endregion

		#region Reader2Tipo
		#region (SqlDataReader r)
		public static TransactionHistory Reader2Tipo(SqlDataReader r)
		{
			TransactionHistory o_TransactionHistory = new TransactionHistory();
			o_TransactionHistory.HistoryID = ConversorTipos.Int32Data(r["HistoryID"].ToString());
			o_TransactionHistory.TransactionID = ConversorTipos.Int32Data(r["TransactionID"].ToString());
			o_TransactionHistory.Status = r["Status"].ToString();
			o_TransactionHistory.Timestamp = ConversorTipos.DateTimeData(r["Timestamp"].ToString());
			return o_TransactionHistory;
		}
		#endregion
		#endregion

		#region Row2Tipo
		#region (DataRow r)
		public static TransactionHistory Row2Tipo(DataRow r)
		{
			TransactionHistory o_TransactionHistory = new TransactionHistory();
			o_TransactionHistory.HistoryID = ConversorTipos.Int32Data(r["HistoryID"].ToString());
			o_TransactionHistory.TransactionID = ConversorTipos.Int32Data(r["TransactionID"].ToString());
			o_TransactionHistory.Status = r["Status"].ToString();
			o_TransactionHistory.Timestamp = ConversorTipos.DateTimeData(r["Timestamp"].ToString());
			return o_TransactionHistory;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Methods
		#region Constructors
		#region TransactionHistory
		#region ()
		public TransactionHistory()
		{
		}
		#endregion

		#region (string conex)
		public TransactionHistory(string conex)
		{
			CadenaConexion = conex;
		}
		#endregion
		#endregion
		#endregion

		#region NuevoTransactionHistory
		#region (DataTable dt, TransactionHistory o_TransactionHistory)
		private static void nuevoTransactionHistory(DataTable dt, TransactionHistory o_TransactionHistory)
		{
			DataRow dr = dt.NewRow();
			TransactionHistory o_T = Row2Tipo(dr);
			o_T.HistoryID = o_TransactionHistory.HistoryID;
			o_T.TransactionID = o_TransactionHistory.TransactionID;
			o_T.Status = o_TransactionHistory.Status;
			o_T.Timestamp = o_TransactionHistory.Timestamp;
			TransactionHistory2Row(o_T, dr);
			dt.Rows.Add(dr);
		}
		#endregion
		#endregion

		#region TransactionHistory2Row
		#region (TransactionHistory o_TransactionHistory, DataRow r)
		private static void TransactionHistory2Row(TransactionHistory o_TransactionHistory, DataRow r)
		{
			//r["HistoryID"] = o_TransactionHistory.HistoryID;
			r["TransactionID"] = o_TransactionHistory.TransactionID;
			r["Status"] = o_TransactionHistory.Status;
			r["Timestamp"] = o_TransactionHistory.Timestamp;
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
					return this.HistoryID.ToString();
				}

				else if (index == 1)
				{
					return this.TransactionID.ToString();
				}

				else if (index == 2)
				{
					return this.Status.ToString();
				}

				else if (index == 3)
				{
					return this.Timestamp.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == 0)
				{
					this.HistoryID = ConversorTipos.Int32Data(value);
				}

				else if (index == 1)
				{
					this.TransactionID = ConversorTipos.Int32Data(value);
				}

				else if (index == 2)
				{
					this.Status = value;
				}

				else if (index == 3)
				{
					this.Timestamp = ConversorTipos.DateTimeData(value);
				}
			}
		}
		#endregion

		#region [string index]
		public string this[string index]
		{
			get
			{
				if (index == "HistoryID")
				{
					return this.HistoryID.ToString();
				}

				else if (index == "TransactionID")
				{
					return this.TransactionID.ToString();
				}

				else if (index == "Status")
				{
					return this.Status.ToString();
				}

				else if (index == "Timestamp")
				{
					return this.Timestamp.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == "HistoryID")
				{
					this.HistoryID = ConversorTipos.Int32Data(value);
				}

				else if (index == "TransactionID")
				{
					this.TransactionID = ConversorTipos.Int32Data(value);
				}

				else if (index == "Status")
				{
					this.Status = value;
				}

				else if (index == "Timestamp")
				{
					this.Timestamp = ConversorTipos.DateTimeData(value);
				}
			}
		}
		#endregion
		#endregion
		#endregion

		#region System
		#region DateTime
		#region Timestamp
		public System.DateTime Timestamp
		{
			get
			{
				return m_Timestamp;
			}
		
			set
			{
				m_Timestamp = value;
			}
		}
		#endregion
		#endregion

		#region Int32
		#region HistoryID
		public System.Int32 HistoryID
		{
			get
			{
				return m_HistoryID;
			}
		
			set
			{
				m_HistoryID = value;
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
		#endregion

		#region String
		#region Status
		public System.String Status
		{
			get
			{
				return ajustarAncho(m_Status, 10);
			}
		
			set
			{
				m_Status = value;
			}
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Variables
		#region String
		public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM TransactionHistory";
		#endregion

		#region System
		#region DateTime
		private System.DateTime m_Timestamp;
		#endregion

		#region Int32
		private System.Int32 m_HistoryID;
		private System.Int32 m_TransactionID;
		#endregion

		#region String
		private System.String m_Status;
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