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
	#region WalletApplications
	public class WalletApplications
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
			DataTable dt = new DataTable("WalletApplications");

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
		#region <WalletApplications>
		#region TablaCol
		#region (string sel)
		public static List<WalletApplications> TablaCol(string sel)
		{
			List<WalletApplications> col = new List<WalletApplications>();

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
						WalletApplications r = Reader2Tipo(reader);
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
			string sel = "SELECT * FROM WalletApplications WHERE AppID = " + this.AppID.ToString();
			return Actualizar(sel);
		}
		#endregion

		#region (string sel)
		public string Actualizar(string sel)
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("WalletApplications");
			cnn = new SqlConnection(CadenaConexion);
			//da = new SqlDataAdapter(CadenaSelect, cnn);
			da = new SqlDataAdapter(sel, cnn);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.UpdateCommand = cb.GetUpdateCommand();
			//string sCommand;
			//sCommand = "UPDATE WalletApplications SET Name = @Name, Platform = @Platform, Notes = @Notes, CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt, DeletedAt = @DeletedAt  WHERE (AppID = @AppID)";
			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
			//da.UpdateCommand.Parameters.AddWithValue("@AppID", AppID);
			//da.UpdateCommand.Parameters.AddWithValue("@Name", Name);
			//da.UpdateCommand.Parameters.AddWithValue("@Platform", Platform);
			////da.UpdateCommand.Parameters.AddWithValue("@Notes", Notes);
			//da.UpdateCommand.Parameters.AddWithValue("@Notes", Notes);
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
				WalletApplications2Row(this, dt.Rows[0]);
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
			string where = "AppID = " + this.AppID.ToString();
			return Borrar(where);
		}
		#endregion

		#region (string where)
		public string Borrar(string where)
		{
			string msg = "";
			string sCon = CadenaConexion;
			string sel = "DELETE FROM WalletApplications WHERE " + where;

			using (SqlConnection con = new SqlConnection(sCon))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand();
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = con;
					//cmd.CommandText = "BorrarWalletApplications";
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
			DataTable dt = new DataTable("WalletApplications");
			cnn = new SqlConnection(CadenaConexion);
			da = new SqlDataAdapter(CadenaSelect, cnn);
			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.InsertCommand = cb.GetInsertCommand();
			//string sCommand;
			//sCommand = "INSERT INTO WalletApplications (Name, Platform, Notes, CreatedAt, UpdatedAt, DeletedAt) VALUES(@Name, @Platform, @Notes, @CreatedAt, @UpdatedAt, @DeletedAt) ";
			//da.InsertCommand = new SqlCommand(sCommand, cnn);
			//da.InsertCommand.Parameters.AddWithValue("@AppID", AppID);
			//da.InsertCommand.Parameters.AddWithValue("@Name", Name);
			//da.InsertCommand.Parameters.AddWithValue("@Platform", Platform);
			////da.InsertCommand.Parameters.AddWithValue("@Notes", Notes);
			//da.InsertCommand.Parameters.AddWithValue("@Notes", Notes);
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

			nuevoWalletApplications(dt, this);

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Se ha creado un nuevo WalletApplications";
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}
		}
		#endregion
		#endregion
		#endregion

		#region WalletApplications
		#region Buscar
		#region (string sWhere)
		public static WalletApplications Buscar(string sWhere)
		{
			WalletApplications o_WalletApplications = null;
			string sel = "SELECT * FROM WalletApplications WHERE " + sWhere;

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
						o_WalletApplications = Reader2Tipo(reader);

						if (o_WalletApplications.AppID > 0)
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

			return o_WalletApplications;
		}
		#endregion
		#endregion

		#region Reader2Tipo
		#region (SqlDataReader r)
		public static WalletApplications Reader2Tipo(SqlDataReader r)
		{
			WalletApplications o_WalletApplications = new WalletApplications();
			o_WalletApplications.AppID = ConversorTipos.Int32Data(r["AppID"].ToString());
			o_WalletApplications.Name = r["Name"].ToString();
			o_WalletApplications.Platform = r["Platform"].ToString();
			o_WalletApplications.Notes = r["Notes"].ToString();
			o_WalletApplications.CreatedAt = ConversorTipos.DateTimeData(r["CreatedAt"].ToString());
			o_WalletApplications.UpdatedAt = ConversorTipos.DateTimeData(r["UpdatedAt"].ToString());
			o_WalletApplications.DeletedAt = ConversorTipos.DateTimeData(r["DeletedAt"].ToString());
			return o_WalletApplications;
		}
		#endregion
		#endregion

		#region Row2Tipo
		#region (DataRow r)
		public static WalletApplications Row2Tipo(DataRow r)
		{
			WalletApplications o_WalletApplications = new WalletApplications();
			o_WalletApplications.AppID = ConversorTipos.Int32Data(r["AppID"].ToString());
			o_WalletApplications.Name = r["Name"].ToString();
			o_WalletApplications.Platform = r["Platform"].ToString();
			o_WalletApplications.Notes = r["Notes"].ToString();
			o_WalletApplications.CreatedAt = ConversorTipos.DateTimeData(r["CreatedAt"].ToString());
			o_WalletApplications.UpdatedAt = ConversorTipos.DateTimeData(r["UpdatedAt"].ToString());
			o_WalletApplications.DeletedAt = ConversorTipos.DateTimeData(r["DeletedAt"].ToString());
			return o_WalletApplications;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Methods
		#region Constructors
		#region WalletApplications
		#region ()
		public WalletApplications()
		{
		}
		#endregion

		#region (string conex)
		public WalletApplications(string conex)
		{
			CadenaConexion = conex;
		}
		#endregion
		#endregion
		#endregion

		#region NuevoWalletApplications
		#region (DataTable dt, WalletApplications o_WalletApplications)
		private static void nuevoWalletApplications(DataTable dt, WalletApplications o_WalletApplications)
		{
			DataRow dr = dt.NewRow();
			WalletApplications o_W = Row2Tipo(dr);
			o_W.AppID = o_WalletApplications.AppID;
			o_W.Name = o_WalletApplications.Name;
			o_W.Platform = o_WalletApplications.Platform;
			o_W.Notes = o_WalletApplications.Notes;
			o_W.CreatedAt = o_WalletApplications.CreatedAt;
			o_W.UpdatedAt = o_WalletApplications.UpdatedAt;
			o_W.DeletedAt = o_WalletApplications.DeletedAt;
			WalletApplications2Row(o_W, dr);
			dt.Rows.Add(dr);
		}
		#endregion
		#endregion

		#region WalletApplications2Row
		#region (WalletApplications o_WalletApplications, DataRow r)
		private static void WalletApplications2Row(WalletApplications o_WalletApplications, DataRow r)
		{
			//r["AppID"] = o_WalletApplications.AppID;
			r["Name"] = o_WalletApplications.Name;
			r["Platform"] = o_WalletApplications.Platform;
			r["Notes"] = o_WalletApplications.Notes;
			r["CreatedAt"] = o_WalletApplications.CreatedAt;
			r["UpdatedAt"] = o_WalletApplications.UpdatedAt;
			r["DeletedAt"] = o_WalletApplications.DeletedAt;
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
					return this.AppID.ToString();
				}

				else if (index == 1)
				{
					return this.Name.ToString();
				}

				else if (index == 2)
				{
					return this.Platform.ToString();
				}

				else if (index == 3)
				{
					return this.Notes.ToString();
				}

				else if (index == 4)
				{
					return this.CreatedAt.ToString();
				}

				else if (index == 5)
				{
					return this.UpdatedAt.ToString();
				}

				else if (index == 6)
				{
					return this.DeletedAt.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == 0)
				{
					this.AppID = ConversorTipos.Int32Data(value);
				}

				else if (index == 1)
				{
					this.Name = value;
				}

				else if (index == 2)
				{
					this.Platform = value;
				}

				else if (index == 3)
				{
					this.Notes = value;
				}

				else if (index == 4)
				{
					this.CreatedAt = ConversorTipos.DateTimeData(value);
				}

				else if (index == 5)
				{
					this.UpdatedAt = ConversorTipos.DateTimeData(value);
				}

				else if (index == 6)
				{
					this.DeletedAt = ConversorTipos.DateTimeData(value);
				}
			}
		}
		#endregion

		#region [string index]
		public string this[string index]
		{
			get
			{
				if (index == "AppID")
				{
					return this.AppID.ToString();
				}

				else if (index == "Name")
				{
					return this.Name.ToString();
				}

				else if (index == "Platform")
				{
					return this.Platform.ToString();
				}

				else if (index == "Notes")
				{
					return this.Notes.ToString();
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
				if (index == "AppID")
				{
					this.AppID = ConversorTipos.Int32Data(value);
				}

				else if (index == "Name")
				{
					this.Name = value;
				}

				else if (index == "Platform")
				{
					this.Platform = value;
				}

				else if (index == "Notes")
				{
					this.Notes = value;
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
		#region AppID
		public System.Int32 AppID
		{
			get
			{
				return m_AppID;
			}

			set
			{
				m_AppID = value;
			}
		}
		#endregion
		#endregion

		#region String
		#region Name
		public System.String Name
		{
			get
			{
				return ajustarAncho(m_Name, 100);
			}

			set
			{
				m_Name = value;
			}
		}
		#endregion

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

		#region Platform
		public System.String Platform
		{
			get
			{
				return ajustarAncho(m_Platform, 50);
			}

			set
			{
				m_Platform = value;
			}
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Variables
		#region String
		public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM WalletApplications";
		#endregion

		#region System
		#region DateTime
		private System.DateTime m_CreatedAt;
		private System.DateTime m_DeletedAt;
		private System.DateTime m_UpdatedAt;
		#endregion

		#region Int32
		private System.Int32 m_AppID;
		#endregion

		#region String
		private System.String m_Name;
		private System.String m_Notes;
		private System.String m_Platform;
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