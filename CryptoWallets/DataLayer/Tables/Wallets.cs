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
	#region Wallets
	public class Wallets
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
			DataTable dt = new DataTable("Wallets");

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
		#region <Wallets>
		#region TablaCol
		#region (string sel)
		public static List<Wallets> TablaCol(string sel)
		{
			List<Wallets> col = new List<Wallets>();

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
						Wallets r = Reader2Tipo(reader);
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
			string sel = "SELECT * FROM Wallets WHERE WalletID = " + this.WalletID.ToString();
			return Actualizar(sel);
		}
		#endregion

		#region (String sel)
		public string Actualizar(string sel)
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("Wallets");
			cnn = new SqlConnection(CadenaConexion);
			//da = new SqlDataAdapter(CadenaSelect, cnn);
			da = new SqlDataAdapter(sel, cnn);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.UpdateCommand = cb.GetUpdateCommand();
			//string sCommand;
			//sCommand = "UPDATE Wallets SET WalletName = @WalletName, ApplicationID = @ApplicationID, CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt, DeletedAt = @DeletedAt  WHERE (WalletID = @WalletID)";
			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
			//da.UpdateCommand.Parameters.AddWithValue("@WalletID", WalletID);
			//da.UpdateCommand.Parameters.AddWithValue("@WalletName", WalletName);
			//da.UpdateCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
			//da.UpdateCommand.Parameters.AddWithValue("@CreatedAt", CreatedAt);
			//da.UpdateCommand.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
			//da.UpdateCommand.Parameters.AddWithValue("@DeletedAt", DeletedAt);

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
				Wallets2Row(this, dt.Rows[0]);
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
		#region (String cadena, int ancho)
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
			string where = "WalletID = " + this.WalletID.ToString();
			return Borrar(where);
		}
		#endregion

		#region (string where)
		public string Borrar(string where)
		{
			string msg = "";
			string sCon = CadenaConexion;
			string sel = "DELETE FROM Wallets WHERE " + where;

			using (SqlConnection con = new SqlConnection(sCon))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand();
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = con;
					//cmd.CommandText = "BorrarWallets";
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
			DataTable dt = new DataTable("Wallets");
			cnn = new SqlConnection(CadenaConexion);
			da = new SqlDataAdapter(CadenaSelect, cnn);
			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.InsertCommand = cb.GetInsertCommand();
			//string sCommand;
			//sCommand = "INSERT INTO Wallets (WalletName, ApplicationID, CreatedAt, UpdatedAt, DeletedAt)  VALUES(@WalletName, @ApplicationID, @CreatedAt, @UpdatedAt, @DeletedAt) ";
			//da.InsertCommand = new SqlCommand(sCommand, cnn);
			//da.InsertCommand.Parameters.AddWithValue("@WalletID", WalletID);
			//da.InsertCommand.Parameters.AddWithValue("@WalletName", WalletName);
			//da.InsertCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
			//da.InsertCommand.Parameters.AddWithValue("@CreatedAt", CreatedAt);
			//da.InsertCommand.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
			//da.InsertCommand.Parameters.AddWithValue("@DeletedAt", DeletedAt);

			try
			{
				da.Fill(dt);
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}

			nuevoWallets(dt, this);

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Se ha creado un nuevo Wallets";
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}
		}
		#endregion
		#endregion
		#endregion

		#region Wallets
		#region Buscar
		#region (String sWhere)
		public static Wallets Buscar(string sWhere)
		{
			Wallets o_Wallets = null;
			string sel = "SELECT * FROM Wallets WHERE " + sWhere;

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
						o_Wallets = Reader2Tipo(reader);

						if (o_Wallets.WalletID > 0)
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

			return o_Wallets;
		}
		#endregion
		#endregion

		#region Reader2Tipo
		#region (SqlDataReader r)
		public static Wallets Reader2Tipo(SqlDataReader r)
		{
			Wallets o_Wallets = new Wallets();
			o_Wallets.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			o_Wallets.WalletName = r["WalletName"].ToString();
			o_Wallets.ApplicationID = ConversorTipos.Int32Data(r["ApplicationID"].ToString());
			o_Wallets.CreatedAt = ConversorTipos.DateTimeData(r["CreatedAt"].ToString());
			o_Wallets.UpdatedAt = ConversorTipos.DateTimeData(r["UpdatedAt"].ToString());
			o_Wallets.DeletedAt = ConversorTipos.DateTimeData(r["DeletedAt"].ToString());
			return o_Wallets;
		}
		#endregion
		#endregion

		#region Row2Tipo
		#region (DataRow r)
		public static Wallets Row2Tipo(DataRow r)
		{
			Wallets o_Wallets = new Wallets();
			o_Wallets.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			o_Wallets.WalletName = r["WalletName"].ToString();
			o_Wallets.ApplicationID = ConversorTipos.Int32Data(r["ApplicationID"].ToString());
			o_Wallets.CreatedAt = ConversorTipos.DateTimeData(r["CreatedAt"].ToString());
			o_Wallets.UpdatedAt = ConversorTipos.DateTimeData(r["UpdatedAt"].ToString());
			o_Wallets.DeletedAt = ConversorTipos.DateTimeData(r["DeletedAt"].ToString());
			return o_Wallets;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Methods
		#region Constructors
		#region Wallets
		#region ()
		public Wallets()
		{
		}
		#endregion

		#region (string conex)
		public Wallets(string conex)
		{
			CadenaConexion = conex;
		}
		#endregion
		#endregion
		#endregion

		#region NuevoWallets
		#region (DataTable dt, Wallets o_Wallets)
		private static void nuevoWallets(DataTable dt, Wallets o_Wallets)
		{
			DataRow dr = dt.NewRow();
			Wallets o_W = Row2Tipo(dr);
			o_W.WalletID = o_Wallets.WalletID;
			o_W.WalletName = o_Wallets.WalletName;
			o_W.ApplicationID = o_Wallets.ApplicationID;
			o_W.CreatedAt = o_Wallets.CreatedAt;
			o_W.UpdatedAt = o_Wallets.UpdatedAt;
			o_W.DeletedAt = o_Wallets.DeletedAt;
			Wallets2Row(o_W, dr);
			dt.Rows.Add(dr);
		}
		#endregion
		#endregion

		#region Wallets2Row
		#region (Wallets o_Wallets, DataRow r)
		private static void Wallets2Row(Wallets o_Wallets, DataRow r)
		{
			//r["WalletID"] = o_Wallets.WalletID;
			r["WalletName"] = o_Wallets.WalletName;
			r["ApplicationID"] = o_Wallets.ApplicationID;
			r["CreatedAt"] = o_Wallets.CreatedAt;
			r["UpdatedAt"] = o_Wallets.UpdatedAt;
			r["DeletedAt"] = o_Wallets.DeletedAt;
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
					return this.WalletID.ToString();
				}

				else if (index == 1)
				{
					return this.WalletName.ToString();
				}

				else if (index == 2)
				{
					return this.ApplicationID.ToString();
				}

				else if (index == 3)
				{
					return this.CreatedAt.ToString();
				}

				else if (index == 4)
				{
					return this.UpdatedAt.ToString();
				}

				else if (index == 5)
				{
					return this.DeletedAt.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == 0)
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}

				else if (index == 1)
				{
					this.WalletName = value;
				}

				else if (index == 2)
				{
					this.ApplicationID = ConversorTipos.Int32Data(value);
				}

				else if (index == 3)
				{
					this.CreatedAt = ConversorTipos.DateTimeData(value);
				}

				else if (index == 4)
				{
					this.UpdatedAt = ConversorTipos.DateTimeData(value);
				}

				else if (index == 5)
				{
					this.DeletedAt = ConversorTipos.DateTimeData(value);
				}
			}
		}
		#endregion

		#region [String index]
		public string this[string index]
		{
			get
			{
				if (index == "WalletID")
				{
					return this.WalletID.ToString();
				}

				else if (index == "WalletName")
				{
					return this.WalletName.ToString();
				}

				else if (index == "ApplicationID")
				{
					return this.ApplicationID.ToString();
				}

				else if (index == "CreatedAt")
				{
					return this.CreatedAt.ToString();
				}

				else if (index == "UpdatedAt")
				{
					return this.UpdatedAt.ToString();
				}

				else if (index == "DeletedAt")
				{
					return this.DeletedAt.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == "WalletID")
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}

				else if (index == "WalletName")
				{
					this.WalletName = value;
				}

				else if (index == "ApplicationID")
				{
					this.ApplicationID = ConversorTipos.Int32Data(value);
				}

				else if (index == "CreatedAt")
				{
					this.CreatedAt = ConversorTipos.DateTimeData(value);
				}

				else if (index == "UpdatedAt")
				{
					this.UpdatedAt = ConversorTipos.DateTimeData(value);
				}

				else if (index == "DeletedAt")
				{
					this.DeletedAt = ConversorTipos.DateTimeData(value);
				}
			}
		}
		#endregion
		#endregion
		#endregion

		#region System
		#region DateTime
		#region CreatedAt
		public System.DateTime CreatedAt
		{
			get
			{
				return m_CreatedAt;
			}

			set
			{
				m_CreatedAt = value;
			}
		}
		#endregion

		#region DeletedAt
		public System.DateTime DeletedAt
		{
			get
			{
				return m_DeletedAt;
			}

			set
			{
				m_DeletedAt = value;
			}
		}
		#endregion

		#region UpdatedAt
		public System.DateTime UpdatedAt
		{
			get
			{
				return m_UpdatedAt;
			}

			set
			{
				m_UpdatedAt = value;
			}
		}
		#endregion
		#endregion

		#region Int32
		#region ApplicationID
		public System.Int32 ApplicationID
		{
			get
			{
				return m_ApplicationID;
			}

			set
			{
				m_ApplicationID = value;
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
		#region WalletName
		public System.String WalletName
		{
			get
			{
				return ajustarAncho(m_WalletName, 100);
			}

			set
			{
				m_WalletName = value;
			}
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Variables
		#region String
		public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM Wallets";
		#endregion

		#region System
		#region DateTime
		private System.DateTime m_CreatedAt;
		private System.DateTime m_DeletedAt;
		private System.DateTime m_UpdatedAt;
		#endregion

		#region Int32
		private System.Int32 m_ApplicationID;
		private System.Int32 m_WalletID;
		#endregion

		#region String
		private System.String m_WalletName;
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