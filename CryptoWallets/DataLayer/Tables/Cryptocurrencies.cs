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
	#region Cryptocurrencies
	public class Cryptocurrencies
	{
		#region Functions
		#region Cryptocurrencies
		#region Buscar
		#region (string sWhere)
		public static Cryptocurrencies Buscar(string sWhere)
		{
			Cryptocurrencies o_Cryptocurrencies = null;
			string sel = "SELECT * FROM Cryptocurrencies WHERE " + sWhere;

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
						o_Cryptocurrencies = Reader2Tipo(reader);

						if (o_Cryptocurrencies.CryptoID > 0)
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

			return o_Cryptocurrencies;
		}
		#endregion
		#endregion

		#region Reader2Tipo
		#region (SqlDataReader r)
		public static Cryptocurrencies Reader2Tipo(SqlDataReader r)
		{
			Cryptocurrencies o_Cryptocurrencies = new Cryptocurrencies();
			o_Cryptocurrencies.CryptoID = ConversorTipos.Int32Data(r["CryptoID"].ToString());
			o_Cryptocurrencies.Name = r["Name"].ToString();
			o_Cryptocurrencies.Abbreviation = r["Abbreviation"].ToString();
			o_Cryptocurrencies.Description = r["Description"].ToString();
			o_Cryptocurrencies.CreatedAt = ConversorTipos.DateTimeData(r["CreatedAt"].ToString());
			o_Cryptocurrencies.UpdatedAt = ConversorTipos.DateTimeData(r["UpdatedAt"].ToString());
			o_Cryptocurrencies.DeletedAt = ConversorTipos.DateTimeData(r["DeletedAt"].ToString());
			return o_Cryptocurrencies;
		}
		#endregion
		#endregion

		#region Row2Tipo
		#region (DataRow r)
		public static Cryptocurrencies Row2Tipo(DataRow r)
		{
			Cryptocurrencies o_Cryptocurrencies = new Cryptocurrencies();
			o_Cryptocurrencies.CryptoID = ConversorTipos.Int32Data(r["CryptoID"].ToString());
			o_Cryptocurrencies.Name = r["Name"].ToString();
			o_Cryptocurrencies.Abbreviation = r["Abbreviation"].ToString();
			o_Cryptocurrencies.Description = r["Description"].ToString();
			o_Cryptocurrencies.CreatedAt = ConversorTipos.DateTimeData(r["CreatedAt"].ToString());
			o_Cryptocurrencies.UpdatedAt = ConversorTipos.DateTimeData(r["UpdatedAt"].ToString());
			o_Cryptocurrencies.DeletedAt = ConversorTipos.DateTimeData(r["DeletedAt"].ToString());
			return o_Cryptocurrencies;
		}
		#endregion
		#endregion
		#endregion

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
			DataTable dt = new DataTable("Cryptocurrencies");

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
		#region <Cryptocurrencies>
		#region TablaCol
		#region (string sel)
		public static List<Cryptocurrencies> TablaCol(string sel)
		{
			List<Cryptocurrencies> col = new List<Cryptocurrencies>();

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
						Cryptocurrencies r = Reader2Tipo(reader);
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
			string sel = "SELECT * FROM Cryptocurrencies WHERE CryptoID = " + this.CryptoID.ToString();
			return Actualizar(sel);
		}
		#endregion

		#region (string sel)
		public string Actualizar(string sel)
		{
			SqlConnection cnn;
			SqlDataAdapter da;
			DataTable dt = new DataTable("Cryptocurrencies");
			cnn = new SqlConnection(CadenaConexion);
			//da = new SqlDataAdapter(CadenaSelect, cnn);
			da = new SqlDataAdapter(sel, cnn);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.UpdateCommand = cb.GetUpdateCommand();
			//string sCommand;
			//sCommand = "UPDATE Cryptocurrencies SET Name = @Name, Abbreviation = @Abbreviation, Description = @Description, CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt, DeletedAt = @DeletedAt  WHERE (CryptoID = @CryptoID)";
			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
			//da.UpdateCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
			//da.UpdateCommand.Parameters.AddWithValue("@Name", Name);
			//da.UpdateCommand.Parameters.AddWithValue("@Abbreviation", Abbreviation);
			////da.UpdateCommand.Parameters.AddWithValue("@Description", Description);
			//da.UpdateCommand.Parameters.AddWithValue("@Description", Description);
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
				Cryptocurrencies2Row(this, dt.Rows[0]);
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
			string where = "CryptoID = " + this.CryptoID.ToString();
			return Borrar(where);
		}
		#endregion

		#region (string where)
		public string Borrar(string where)
		{
			string msg = "";
			string sCon = CadenaConexion;
			string sel = "DELETE FROM Cryptocurrencies WHERE " + where;

			using (SqlConnection con = new SqlConnection(sCon))
			{
				SqlTransaction tran = null;

				try
				{
					SqlCommand cmd = new SqlCommand();
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = con;
					//cmd.CommandText = "BorrarCryptocurrencies";
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
			DataTable dt = new DataTable("Cryptocurrencies");
			cnn = new SqlConnection(CadenaConexion);
			da = new SqlDataAdapter(CadenaSelect, cnn);
			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			SqlCommandBuilder cb = new SqlCommandBuilder(da);
			da.InsertCommand = cb.GetInsertCommand();
			//string sCommand;
			//sCommand = "INSERT INTO Cryptocurrencies (Name, Abbreviation, Description, CreatedAt, UpdatedAt, DeletedAt)  VALUES(@Name, @Abbreviation, @Description, @CreatedAt, @UpdatedAt, @DeletedAt) ";
			//da.InsertCommand = new SqlCommand(sCommand, cnn);
			//da.InsertCommand.Parameters.AddWithValue("@CryptoID", CryptoID);
			//da.InsertCommand.Parameters.AddWithValue("@Name", Name);
			//da.InsertCommand.Parameters.AddWithValue("@Abbreviation", Abbreviation);
			////da.InsertCommand.Parameters.AddWithValue("@Description", Description);
			//da.InsertCommand.Parameters.AddWithValue("@Description", Description);
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

			nuevoCryptocurrencies(dt, this);

			try
			{
				da.Update(dt);
				dt.AcceptChanges();
				return "Se ha creado un nuevo Cryptocurrencies";
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
		#region Cryptocurrencies
		#region ()
		public Cryptocurrencies()
		{
		}
		#endregion

		#region (string conex)
		public Cryptocurrencies(string conex)
		{
			CadenaConexion = conex;
		}
		#endregion
		#endregion
		#endregion

		#region Cryptocurrencies2Row
		#region (Cryptocurrencies o_Cryptocurrencies, DataRow r)
		private static void Cryptocurrencies2Row(Cryptocurrencies o_Cryptocurrencies, DataRow r)
		{
			//r["CryptoID"] = o_Cryptocurrencies.CryptoID;
			r["Name"] = o_Cryptocurrencies.Name;
			r["Abbreviation"] = o_Cryptocurrencies.Abbreviation;
			r["Description"] = o_Cryptocurrencies.Description;
			r["CreatedAt"] = o_Cryptocurrencies.CreatedAt;
			r["UpdatedAt"] = o_Cryptocurrencies.UpdatedAt;
			r["DeletedAt"] = o_Cryptocurrencies.DeletedAt;
		}
		#endregion
		#endregion

		#region NuevoCryptocurrencies
		#region (DataTable dt, Cryptocurrencies o_Cryptocurrencies)
		private static void nuevoCryptocurrencies(DataTable dt, Cryptocurrencies o_Cryptocurrencies)
		{
			DataRow dr = dt.NewRow();
			Cryptocurrencies o_C = Row2Tipo(dr);
			o_C.CryptoID = o_Cryptocurrencies.CryptoID;
			o_C.Name = o_Cryptocurrencies.Name;
			o_C.Abbreviation = o_Cryptocurrencies.Abbreviation;
			o_C.Description = o_Cryptocurrencies.Description;
			o_C.CreatedAt = o_Cryptocurrencies.CreatedAt;
			o_C.UpdatedAt = o_Cryptocurrencies.UpdatedAt;
			o_C.DeletedAt = o_Cryptocurrencies.DeletedAt;
			Cryptocurrencies2Row(o_C, dr);
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
					return this.CryptoID.ToString();
				}

				else if (index == 1)
				{
					return this.Name.ToString();
				}

				else if (index == 2)
				{
					return this.Abbreviation.ToString();
				}

				else if (index == 3)
				{
					return this.Description.ToString();
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
					this.CryptoID = ConversorTipos.Int32Data(value);
				}

				else if (index == 1)
				{
					this.Name = value;
				}

				else if (index == 2)
				{
					this.Abbreviation = value;
				}

				else if (index == 3)
				{
					this.Description = value;
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
				if (index == "CryptoID")
				{
					return this.CryptoID.ToString();
				}

				else if (index == "Name")
				{
					return this.Name.ToString();
				}

				else if (index == "Abbreviation")
				{
					return this.Abbreviation.ToString();
				}

				else if (index == "Description")
				{
					return this.Description.ToString();
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
				if (index == "CryptoID")
				{
					this.CryptoID = ConversorTipos.Int32Data(value);
				}

				else if (index == "Name")
				{
					this.Name = value;
				}

				else if (index == "Abbreviation")
				{
					this.Abbreviation = value;
				}

				else if (index == "Description")
				{
					this.Description = value;
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
		#endregion

		#region String
		#region Abbreviation
		public System.String Abbreviation
		{
			get
			{
				return ajustarAncho(m_Abbreviation, 10);
			}

			set
			{
				m_Abbreviation = value;
			}
		}
		#endregion

		#region Description
		public System.String Description
		{
			get
			{
				//return ajustarAncho(m_Description,2147483647);
				return m_Description;
			}

			set
			{
				m_Description = value;
			}
		}
		#endregion

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
		#endregion
		#endregion
		#endregion

		#region Variables
		#region String
		public static string CadenaConexion = @"Data Source=DESKTOP-MDE3BK6; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
		public static string CadenaSelect = "SELECT * FROM Cryptocurrencies";
		#endregion

		#region System
		#region DateTime
		private System.DateTime m_CreatedAt;
		private System.DateTime m_DeletedAt;
		private System.DateTime m_UpdatedAt;
		#endregion

		#region Int32
		private System.Int32 m_CryptoID;
		#endregion

		#region String
		private System.String m_Abbreviation;
		private System.String m_Description;
		private System.String m_Name;
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