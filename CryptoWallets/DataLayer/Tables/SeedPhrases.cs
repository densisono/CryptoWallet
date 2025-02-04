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
	#region SeedPhrases
	public class SeedPhrases
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
			DataTable dt = new DataTable("SeedPhrases");

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
		#region <SeedPhrases>
		#region TablaCol
		#region (string sel)
		public static List<SeedPhrases> TablaCol(string sel)
		{
			List<SeedPhrases> col = new List<SeedPhrases>();

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
						SeedPhrases r = Reader2Tipo(reader);
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

		#region SeedPhrases
		#region Buscar
		#region (string sWhere)
		public static SeedPhrases Buscar(string sWhere)
		{
			SeedPhrases o_SeedPhrases = null;
			string sel = "SELECT * FROM SeedPhrases WHERE " + sWhere;

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
						o_SeedPhrases = Reader2Tipo(reader);

						if (o_SeedPhrases.SeedID > 0)
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

			return o_SeedPhrases;
		}
		#endregion
		#endregion

		#region Reader2Tipo
		#region (SqlDataReader r)
		public static SeedPhrases Reader2Tipo(SqlDataReader r)
		{
			SeedPhrases o_SeedPhrases = new SeedPhrases();
			o_SeedPhrases.SeedID = ConversorTipos.Int32Data(r["SeedID"].ToString());
			o_SeedPhrases.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			o_SeedPhrases.Phrase = r["Phrase"].ToString();
			return o_SeedPhrases;
		}
		#endregion
		#endregion

		#region Row2Tipo
		#region (DataRow r)
		public static SeedPhrases Row2Tipo(DataRow r)
		{
			SeedPhrases o_SeedPhrases = new SeedPhrases();
			o_SeedPhrases.SeedID = ConversorTipos.Int32Data(r["SeedID"].ToString());
			o_SeedPhrases.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
			o_SeedPhrases.Phrase = r["Phrase"].ToString();
			return o_SeedPhrases;
		}
		#endregion
		#endregion
		#endregion

		#region String
		#region Actualizar
		#region ()
		public string Actualizar()
		{
			string sel = "SELECT * FROM SeedPhrases WHERE SeedID = " + this.SeedID.ToString();
			return Actualizar(sel);
		}
		#endregion

		#region (string sel)
		public string Actualizar(string sel)
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("SeedPhrases");
			cnn = new SqlConnection(CadenaConexion);
			//da = new SqlDataAdapter(CadenaSelect, cnn);
			da = new SqlDataAdapter(sel, cnn);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.UpdateCommand = cb.GetUpdateCommand();
			//string sCommand;
			//sCommand = "UPDATE SeedPhrases SET WalletID = @WalletID, Phrase = @Phrase  WHERE (SeedID = @SeedID)";
			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
			//da.UpdateCommand.Parameters.AddWithValue("@SeedID", SeedID);
			//da.UpdateCommand.Parameters.AddWithValue("@WalletID", WalletID);
			////da.UpdateCommand.Parameters.AddWithValue("@Phrase", Phrase);
			//da.UpdateCommand.Parameters.AddWithValue("@Phrase", Phrase);

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
				SeedPhrases2Row(this, dt.Rows[0]);
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
			string where = "SeedID = " + this.SeedID.ToString();
			return Borrar(where);
		}
		#endregion

		#region (string where)
		public string Borrar(string where)
		{
			string msg = "";
			string sCon = CadenaConexion;
			string sel = "DELETE FROM SeedPhrases WHERE " + where;

			using (SqlConnection con = new SqlConnection(sCon))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand();
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = con;
					//cmd.CommandText = "BorrarSeedPhrases";
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
			DataTable dt = new DataTable("SeedPhrases");
			cnn = new SqlConnection(CadenaConexion);
			da = new SqlDataAdapter(CadenaSelect, cnn);
			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.InsertCommand = cb.GetInsertCommand();
			//string sCommand;
			//sCommand = "INSERT INTO SeedPhrases (WalletID, Phrase)  VALUES(@WalletID, @Phrase) ";
			//da.InsertCommand = new SqlCommand(sCommand, cnn);
			//da.InsertCommand.Parameters.AddWithValue("@SeedID", SeedID);
			//da.InsertCommand.Parameters.AddWithValue("@WalletID", WalletID);
			////da.InsertCommand.Parameters.AddWithValue("@Phrase", Phrase);
			//da.InsertCommand.Parameters.AddWithValue("@Phrase", Phrase);

			try
			{
				da.Fill(dt);
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}

			nuevoSeedPhrases(dt, this);

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Se ha creado un nuevo SeedPhrases";
			}

			catch (Exception ex)
			{
				return "ERROR: " + ex.Message;
			}
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Methods
		#region Constructors
		#region SeedPhrases
		#region ()
		public SeedPhrases()
		{
		}
		#endregion

		#region (string conex)
		public SeedPhrases(string conex)
		{
			CadenaConexion = conex;
		}
		#endregion
		#endregion
		#endregion

		#region NuevoSeedPhrases
		#region (DataTable dt, SeedPhrases o_SeedPhrases)
		private static void nuevoSeedPhrases(DataTable dt, SeedPhrases o_SeedPhrases)
		{
			DataRow dr = dt.NewRow();
			SeedPhrases o_S = Row2Tipo(dr);
			o_S.SeedID = o_SeedPhrases.SeedID;
			o_S.WalletID = o_SeedPhrases.WalletID;
			o_S.Phrase = o_SeedPhrases.Phrase;
			SeedPhrases2Row(o_S, dr);
			dt.Rows.Add(dr);
		}
		#endregion
		#endregion

		#region SeedPhrases2Row
		#region (SeedPhrases o_SeedPhrases, DataRow r)
		private static void SeedPhrases2Row(SeedPhrases o_SeedPhrases, DataRow r)
		{
			//r["SeedID"] = o_SeedPhrases.SeedID;
			r["WalletID"] = o_SeedPhrases.WalletID;
			r["Phrase"] = o_SeedPhrases.Phrase;
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
					return this.SeedID.ToString();
				}

				else if (index == 1)
				{
					return this.WalletID.ToString();
				}

				else if (index == 2)
				{
					return this.Phrase.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == 0)
				{
					this.SeedID = ConversorTipos.Int32Data(value);
				}

				else if (index == 1)
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}

				else if (index == 2)
				{
					this.Phrase = value;
				}
			}
		}
		#endregion

		#region [string index]
		public string this[string index]
		{
			get
			{
				if (index == "SeedID")
				{
					return this.SeedID.ToString();
				}

				else if (index == "WalletID")
				{
					return this.WalletID.ToString();
				}

				else if (index == "Phrase")
				{
					return this.Phrase.ToString();
				}

				return "<NULO>";
			}

			set
			{
				if (index == "SeedID")
				{
					this.SeedID = ConversorTipos.Int32Data(value);
				}

				else if (index == "WalletID")
				{
					this.WalletID = ConversorTipos.Int32Data(value);
				}

				else if (index == "Phrase")
				{
					this.Phrase = value;
				}
			}
		}
		#endregion
		#endregion
		#endregion

		#region System
		#region Int32
		#region SeedID
		public System.Int32 SeedID
		{
			get
			{
				return m_SeedID;
			}

			set
			{
				m_SeedID = value;
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
		#region Phrase
		public System.String Phrase
		{
			get
			{
				//return ajustarAncho(m_Phrase,2147483647);
				return m_Phrase;
			}

			set
			{
				m_Phrase = value;
			}
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Variables
		#region String
		public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM SeedPhrases";
		#endregion

		#region System
		#region Int32
		private System.Int32 m_SeedID;
		private System.Int32 m_WalletID;
		#endregion

		#region String
		private System.String m_Phrase;
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