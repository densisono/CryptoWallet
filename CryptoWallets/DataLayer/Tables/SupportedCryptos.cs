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
	#region SupportedCryptos
	public class SupportedCryptos
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
			DataTable dt = new DataTable("SupportedCryptos");

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
		#region <SupportedCryptos>
		#region TablaCol
		#region (string sel)
		public static List<SupportedCryptos> TablaCol(string sel)
		{
			List<SupportedCryptos> col = new List<SupportedCryptos>();

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
						SupportedCryptos r = Reader2Tipo(reader);
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
			string sel = "SELECT * FROM SupportedCryptos WHERE ID = " + this.ID.ToString();
			return Actualizar(sel);
		}
		#endregion

		#region (string sel)
		public string Actualizar(string sel)
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("SupportedCryptos");
			cnn = new SqlConnection(CadenaConexion);
			//da = new SqlDataAdapter(CadenaSelect, cnn);
			da = new SqlDataAdapter(sel, cnn);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.UpdateCommand = cb.GetUpdateCommand();
			//string sCommand;
			//sCommand = "UPDATE SupportedCryptos SET CryptoID = @CryptoID, WalletID = @WalletID  WHERE (ID = @ID)";
			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
			//da.UpdateCommand.Parameters.AddWithValue("@ID", ID);
			//da.UpdateCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
			//da.UpdateCommand.Parameters.AddWithValue("@WalletID", WalletID);

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
				SupportedCryptos2Row(this, dt.Rows[0]);
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
			string where = "ID = " + this.ID.ToString();
			return Borrar(where);
		}
		#endregion

		#region (string where)
		public string Borrar(string where)
		{
			string msg = "";
			string sCon = CadenaConexion;
			string sel = "DELETE FROM SupportedCryptos WHERE " + where;

			using (SqlConnection con = new SqlConnection(sCon))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand();
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = con;
					//cmd.CommandText = "BorrarSupportedCryptos";
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
			DataTable dt = new DataTable("SupportedCryptos");
			cnn = new SqlConnection(CadenaConexion);
			da = new SqlDataAdapter(CadenaSelect, cnn);
			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.InsertCommand = cb.GetInsertCommand();
			//string sCommand;
			//sCommand = "INSERT INTO SupportedCryptos (CryptoID, WalletID)  VALUES(@CryptoID, @WalletID) ";
			//da.InsertCommand = new SqlCommand(sCommand, cnn);
			//da.InsertCommand.Parameters.AddWithValue("@ID", ID);
			//da.InsertCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
			//da.InsertCommand.Parameters.AddWithValue("@WalletID", WalletID);

			try
			{
				da.Fill(dt);
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}

			nuevoSupportedCryptos(dt, this);

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Se ha creado un nuevo SupportedCryptos";
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}
		}
		#endregion
		#endregion
		#endregion

		#region SupportedCryptos
		#region Buscar
		#region (string sWhere)
		public static SupportedCryptos Buscar(string sWhere)
		{
			SupportedCryptos o_SupportedCryptos = null;
			string sel = "SELECT * FROM SupportedCryptos WHERE " + sWhere;

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
						o_SupportedCryptos = Reader2Tipo(reader);

						if (o_SupportedCryptos.ID > 0)
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

			return o_SupportedCryptos;
		}
		#endregion
		#endregion

		#region Reader2Tipo
		#region (SqlDataReader r)
		public static SupportedCryptos Reader2Tipo(SqlDataReader r)
		{
			SupportedCryptos o_SupportedCryptos = new SupportedCryptos();
			o_SupportedCryptos.ID = ConversorTipos.Int32Data(r["ID"].ToString());
			o_SupportedCryptos.CryptoID = ConversorTipos.Int32Data(r["CryptoID"].ToString());
			o_SupportedCryptos.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			return o_SupportedCryptos;
		}
		#endregion
		#endregion

		#region Row2Tipo
		#region (DataRow r)
		public static SupportedCryptos Row2Tipo(DataRow r)
		{
			SupportedCryptos o_SupportedCryptos = new SupportedCryptos();
			o_SupportedCryptos.ID = ConversorTipos.Int32Data(r["ID"].ToString());
			o_SupportedCryptos.CryptoID = ConversorTipos.Int32Data(r["CryptoID"].ToString());
			o_SupportedCryptos.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			return o_SupportedCryptos;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Methods
		#region Constructors
		#region SupportedCryptos
		#region ()
		public SupportedCryptos()
		{
		}
		#endregion

		#region (string conex)
		public SupportedCryptos(string conex)
		{
			CadenaConexion = conex;
		}
		#endregion
		#endregion
		#endregion

		#region NuevoSupportedCryptos
		#region (DataTable dt, SupportedCryptos o_SupportedCryptos)
		private static void nuevoSupportedCryptos(DataTable dt, SupportedCryptos o_SupportedCryptos)
		{
			DataRow dr = dt.NewRow();
			SupportedCryptos o_S = Row2Tipo(dr);
			o_S.ID = o_SupportedCryptos.ID;
			o_S.CryptoID = o_SupportedCryptos.CryptoID;
			o_S.WalletID = o_SupportedCryptos.WalletID;
			SupportedCryptos2Row(o_S, dr);
			dt.Rows.Add(dr);
		}
		#endregion
		#endregion

		#region SupportedCryptos2Row
		#region (SupportedCryptos o_SupportedCryptos, DataRow r)
		private static void SupportedCryptos2Row(SupportedCryptos o_SupportedCryptos, DataRow r)
		{
			//r["ID"] = o_SupportedCryptos.ID;
			r["CryptoID"] = o_SupportedCryptos.CryptoID;
			r["WalletID"] = o_SupportedCryptos.WalletID;
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
					return this.ID.ToString();
				}

				else if (index == 1)
				{
					return this.CryptoID.ToString();
				}

				else if (index == 2)
				{
					return this.WalletID.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == 0)
				{
					this.ID = ConversorTipos.Int32Data(value);
				}

				else if (index == 1)
				{
					this.CryptoID = ConversorTipos.Int32Data(value);
				}

				else if (index == 2)
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}
			}
		}
		#endregion

		#region [string index]
		public string this[string index]
		{
			get
			{
				if (index == "ID")
				{
					return this.ID.ToString();
				}

				else if (index == "CryptoID")
				{
					return this.CryptoID.ToString();
				}

				else if (index == "WalletID")
				{
					return this.WalletID.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == "ID")
				{
					this.ID = ConversorTipos.Int32Data(value);
				}

				else if (index == "CryptoID")
				{
					this.CryptoID = ConversorTipos.Int32Data(value);
				}

				else if (index == "WalletID")
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}
			}
		}
		#endregion
		#endregion
		#endregion

		#region System
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

		#region ID
		public System.Int32 ID
		{
			get
			{
				return m_ID;
			}

			set
			{
				m_ID = value;
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
		#endregion
		#endregion

		#region Variables
		#region String
		public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM SupportedCryptos";
		#endregion

		#region System
		#region Int32
		private System.Int32 m_CryptoID;
		private System.Int32 m_ID;
		private System.Int32 m_WalletID;
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