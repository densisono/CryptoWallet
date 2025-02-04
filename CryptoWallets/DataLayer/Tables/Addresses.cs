//#region Using
//#region Microsoft
//#region Data
//#region SqlClient
////using Microsoft.Data.SqlClient;
//#endregion
//#endregion
//#endregion

//#region System
//using System;

//#region Collections
//#region Generic
//using System.Collections.Generic;
//#endregion
//#endregion

//#region Data
//using System.Data;

//#region SqlClient
//using System.Data.SqlClient;
//#endregion
//#endregion
//#endregion
//#endregion

//#region Namespace
//#region PSS
//#region DHPM
//#region CryptoWallets
//#region DataLayer
//#region Tables
//namespace PSS.DHPM.CryptoWallets.DataLayer.Tables
//{
//	#region Class	
//	#region Addresses	
//	public class Addresses
//	{
//		#region Functions
//		#region Addresses
//		#region Buscar
//		#region (string sWhere)
//		public static Addresses Buscar(string sWhere)
//		{
//			Addresses o_Addresses = null;
//			string sel = "SELECT * FROM Addresses WHERE " + sWhere;

//			using (SqlConnection con = new SqlConnection(CadenaConexion))
//			{
//				SqlCommand cmd = new SqlCommand();
//				SqlDataReader reader;
//				cmd.CommandType = CommandType.Text;
//				cmd.Connection = con;
//				cmd.CommandText = sel;

//				try
//				{
//					con.Open();
//					reader = cmd.ExecuteReader();

//					while (reader.Read())
//					{
//						o_Addresses = Reader2Tipo(reader);

//						if (o_Addresses.AddressID > 0)
//						{
//							break;
//						}
//					}

//					reader.Close();
//					con.Close();
//				}

//				catch (Exception ex)
//				{
//					return null;
//				}

//				finally
//				{
//					if (!(con == null))
//					{
//						con.Close();
//					}
//				}
//			}

//			return o_Addresses;
//		}
//		#endregion
//		#endregion

//		#region Reader2Tipo
//		#region (SqlDataReader r)
//		public static Addresses Reader2Tipo(SqlDataReader r)
//		{
//			Addresses o_Addresses = new Addresses();
//			o_Addresses.AddressID = ConversorTipos.Int32Data(r["AddressID"].ToString());
//			o_Addresses.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
//			o_Addresses.PublicKey = r["PublicKey"].ToString();
//			//o_Addresses.PrivateKey = r["PrivateKey"];
//			return o_Addresses;
//		}
//		#endregion
//		#endregion

//		#region Row2Tipo
//		#region (DataRow r)
//		public static Addresses Row2Tipo(DataRow r)
//		{
//			Addresses o_Addresses = new Addresses();
//			o_Addresses.AddressID = ConversorTipos.Int32Data(r["AddressID"].ToString());
//			o_Addresses.WalletID = ConversorTipos.Int32Data(r["WalletID"].ToString());
//			o_Addresses.PublicKey = r["PublicKey"].ToString();
//			//o_Addresses.PrivateKey = r["PrivateKey"];
//			return o_Addresses;
//		}
//		#endregion
//		#endregion
//		#endregion

//		#region DataTable
//		#region Tabla
//		#region ()
//		public static DataTable Tabla()
//		{
//			return Tabla(CadenaSelect);
//		}
//		#endregion

//		#region (string sel)
//		public static DataTable Tabla(string sel)
//		{
//			SqlDataAdapter da;
//			DataTable dt = new DataTable("Addresses");

//			try
//			{
//				da = new SqlDataAdapter(sel, CadenaConexion);
//				da.Fill(dt);
//			}

//			catch
//			{
//				return null;
//			}

//			return dt;
//		}
//		#endregion
//		#endregion
//		#endregion

//		#region List
//		#region <Addresses>
//		#region TablaCol
//		#region (string sel)
//		public static List<Addresses> TablaCol(string sel)
//		{
//			List<Addresses> col = new List<Addresses>();

//			using (SqlConnection con = new SqlConnection(CadenaConexion))
//			{
//				SqlCommand cmd = new SqlCommand();
//				SqlDataReader reader;
//				cmd.CommandType = CommandType.Text;
//				cmd.Connection = con;
//				cmd.CommandText = sel;

//				try
//				{
//					con.Open();
//					reader = cmd.ExecuteReader();

//					while (reader.Read())
//					{
//						Addresses r = Reader2Tipo(reader);
//						col.Add(r);
//					}

//					reader.Close();
//					con.Close();

//				}

//				catch (Exception ex)
//				{
//					return col;
//				}

//				finally
//				{
//					if (!(con == null))
//					{
//						con.Close();
//					}
//				}
//			}

//			return col;
//		}
//		#endregion
//		#endregion
//		#endregion
//		#endregion

//		#region String
//		#region Actualizar
//		#region ()
//		public string Actualizar()
//		{
//			string sel = "SELECT * FROM Addresses WHERE AddressID = " + this.AddressID.ToString();
//			return Actualizar(sel);
//		}
//		#endregion

//		#region (string sel)
//		public string Actualizar(string sel)
//		{
//			SqlConnection cnn;
//			SqlDataAdapter da;
//			DataTable dt = new DataTable("Addresses");
//			cnn = new SqlConnection(CadenaConexion);
//			//da = new SqlDataAdapter(CadenaSelect, cnn);
//			da = new SqlDataAdapter(sel, cnn);
//			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//			SqlCommandBuilder cb = new SqlCommandBuilder(da);
//			da.UpdateCommand = cb.GetUpdateCommand();
//			//string sCommand;
//			//sCommand = "UPDATE Addresses SET WalletID = @WalletID, PublicKey = @PublicKey, PrivateKey = @PrivateKey  WHERE (AddressID = @AddressID)";
//			//da.UpdateCommand = new SqlCommand(sCommand, cnn);
//			//da.UpdateCommand.Parameters.AddWithValue("@AddressID", AddressID);
//			//da.UpdateCommand.Parameters.AddWithValue("@WalletID", WalletID);
//			////da.UpdateCommand.Parameters.AddWithValue("@PublicKey", PublicKey);
//			//da.UpdateCommand.Parameters.AddWithValue("@PublicKey", PublicKey);
//			//da.UpdateCommand.Parameters.AddWithValue("@PrivateKey", PrivateKey);

//			try
//			{
//				da.Fill(dt);
//			}

//			catch (Exception ex)
//			{
//				return "ERROR: " + ex.Message;
//			}

//			if (dt.Rows.Count == 0)
//			{
//				return Crear();
//			}

//			else
//			{
//				Addresses2Row(this, dt.Rows[0]);
//			}

//			try
//			{
//				da.Update(dt);
//				dt.AcceptChanges();
//				return "Actualizado correctamente";
//			}

//			catch (Exception ex)
//			{
//				return "ERROR: " + ex.Message;
//			}
//		}
//		#endregion
//		#endregion

//		#region AjustarAncho
//		#region (string cadena, int ancho)
//		private string ajustarAncho(string cadena, int ancho)
//		{
//			System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
//			return (cadena + sb.ToString()).Substring(0, ancho).Trim();
//		}
//		#endregion
//		#endregion

//		#region Borrar
//		#region ()
//		public string Borrar()
//		{
//			string where = "AddressID = " + this.AddressID.ToString();
//			return Borrar(where);
//		}
//		#endregion

//		#region (string where)
//		public string Borrar(string where)
//		{
//			string msg = "";
//			string sCon = CadenaConexion;
//			string sel = "DELETE FROM Addresses WHERE " + where;

//			using (SqlConnection con = new SqlConnection(sCon))
//			{
//				SqlTransaction tran = null;

//				try
//				{
//					SqlCommand cmd = new SqlCommand();
//					//cmd.CommandType = CommandType.StoredProcedure;
//					cmd.CommandType = CommandType.Text;
//					cmd.Connection = con;
//					//cmd.CommandText = "BorrarAddresses";
//					cmd.CommandText = sel;
//					con.Open();
//					tran = con.BeginTransaction();
//					cmd.Transaction = tran;
//					cmd.ExecuteNonQuery();
//					tran.Commit();
//					msg = "Eliminado correctamente los registros con : " + where + ".";
//				}

//				catch (Exception ex)
//				{
//					msg = "ERROR al eliminar los registros con : " + where + "." + ex.Message;

//					try
//					{
//						tran.Rollback();
//					}

//					catch (Exception ex2)
//					{
//						msg = $"ERROR RollBack: {ex2.Message})";
//					}

//					finally
//					{
//						if (!(con == null))
//						{
//							con.Close();
//						}
//					}
//				}
//			}

//			return msg;
//		}
//		#endregion
//		#endregion

//		#region Crear
//		#region ()
//		public string Crear()
//		{
//			SqlConnection cnn;
//			SqlDataAdapter da;
//			DataTable dt = new DataTable("Addresses");
//			cnn = new SqlConnection(CadenaConexion);
//			da = new SqlDataAdapter(CadenaSelect, cnn);
//			//da = new SqlDataAdapter(CadenaSelect, CadenaConexion);
//			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
//			SqlCommandBuilder cb = new SqlCommandBuilder(da);
//			da.InsertCommand = cb.GetInsertCommand();
//			//string sCommand;
//			//sCommand = "INSERT INTO Addresses (WalletID, PublicKey, PrivateKey)  VALUES(@WalletID, @PublicKey, @PrivateKey) ";
//			//da.InsertCommand = new SqlCommand(sCommand, cnn);
//			//da.InsertCommand.Parameters.AddWithValue("@AddressID", AddressID);
//			//da.InsertCommand.Parameters.AddWithValue("@WalletID", WalletID);
//			////da.InsertCommand.Parameters.AddWithValue("@PublicKey", PublicKey);
//			//da.InsertCommand.Parameters.AddWithValue("@PublicKey", PublicKey);
//			//da.InsertCommand.Parameters.AddWithValue("@PrivateKey", PrivateKey);

//			try
//			{
//				da.Fill(dt);
//			}

//			catch (Exception ex)
//			{
//				return "ERROR: " + ex.Message;
//			}

//			nuevoAddresses(dt, this);

//			try
//			{
//				da.Update(dt);
//				dt.AcceptChanges();
//				return "Se ha creado un nuevo Addresses";
//			}

//			catch (Exception ex)
//			{
//				return "ERROR: " + ex.Message;
//			}
//		}
//		#endregion
//		#endregion
//		#endregion
//		#endregion

//		#region Methods
//		#region Addresses2Row
//		#region (Addresses o_Addresses, DataRow r)
//		private static void Addresses2Row(Addresses o_Addresses, DataRow r)
//		{
//			//r["AddressID"] = o_Addresses.AddressID;
//			r["WalletID"] = o_Addresses.WalletID;
//			r["PublicKey"] = o_Addresses.PublicKey;
//			r["PrivateKey"] = o_Addresses.PrivateKey;
//		}
//		#endregion
//		#endregion

//		#region Constructors
//		#region Addresses
//		#region ()
//		public Addresses()
//		{
//		}
//		#endregion

//		#region (string conex)
//		public Addresses(string conex)
//		{
//			CadenaConexion = conex;
//		}
//		#endregion
//		#endregion
//		#endregion

//		#region NuevoAddresses
//		#region (DataTable dt, Addresses o_Addresses)
//		private static void nuevoAddresses(DataTable dt, Addresses o_Addresses)
//		{
//			DataRow dr = dt.NewRow();
//			Addresses o_A = Row2Tipo(dr);
//			o_A.AddressID = o_Addresses.AddressID;
//			o_A.WalletID = o_Addresses.WalletID;
//			o_A.PublicKey = o_Addresses.PublicKey;
//			o_A.PrivateKey = o_Addresses.PrivateKey;
//			Addresses2Row(o_A, dr);
//			dt.Rows.Add(dr);
//		}
//		#endregion
//		#endregion
//		#endregion

//		#region Properites
//		#region String
//		#region This
//		#region [int index]
//		public string this[int index]
//		{
//			get
//			{
//				if (index == 0)
//				{
//					return this.AddressID.ToString();
//				}

//				else if (index == 1)
//				{
//					return this.WalletID.ToString();
//				}

//				else if (index == 2)
//				{
//					return this.PublicKey.ToString();
//				}

//				else if (index == 3)
//				{
//					return this.PrivateKey.ToString();
//				}

//				return "<NULO>";
//			}

//			set
//			{
//				if (index == 0)
//				{
//					this.AddressID = ConversorTipos.Int32Data(value);
//				}

//				else if (index == 1)
//				{
//					this.WalletID = ConversorTipos.Int32Data(value);
//				}

//				else if (index == 2)
//				{
//					this.PublicKey = value;
//				}

//				else if (index == 3)
//				{
//				}
//			}
//		}
//		#endregion

//		#region [string index]
//		public string this[string index]
//		{
//			get
//			{
//				if (index == "AddressID")
//				{
//					return this.AddressID.ToString();
//				}

//				else if (index == "WalletID")
//				{
//					return this.WalletID.ToString();
//				}

//				else if (index == "PublicKey")
//				{
//					return this.PublicKey.ToString();
//				}

//				else if (index == "PrivateKey")
//				{
//					return this.PrivateKey.ToString();
//				}

//				return "<NULO>";
//			}

//			set
//			{
//				if (index == "AddressID")
//				{
//					this.AddressID = ConversorTipos.Int32Data(value);
//				}

//				else if (index == "WalletID")
//				{
//					this.WalletID = ConversorTipos.Int32Data(value);
//				}

//				else if (index == "PublicKey")
//				{
//					this.PublicKey = value;
//				}

//				else if (index == "PrivateKey")
//				{
//				}
//			}
//		}
//		#endregion
//		#endregion
//		#endregion

//		#region System
//		#region Byte
//		#region PrivateKey
//		public System.Byte[] PrivateKey
//		{
//			get
//			{
//				return m_PrivateKey;
//			}

//			set
//			{
//				m_PrivateKey = value;
//			}
//		}
//		#endregion
//		#endregion

//		#region Int32
//		#region AddressID
//		public System.Int32 AddressID
//		{
//			get
//			{
//				return m_AddressID;
//			}

//			set
//			{
//				m_AddressID = value;
//			}
//		}
//		#endregion

//		#region WalletID
//		public System.Int32 WalletID
//		{
//			get
//			{
//				return m_WalletID;
//			}

//			set
//			{
//				m_WalletID = value;
//			}
//		}
//		#endregion
//		#endregion

//		#region String
//		#region PublicKey
//		public System.String PublicKey
//		{
//			get
//			{
//				//return ajustarAncho(m_PublicKey,2147483647);
//				return m_PublicKey;
//			}

//			set
//			{
//				m_PublicKey = value;
//			}
//		}
//		#endregion
//		#endregion
//		#endregion
//		#endregion

//		#region Variables
//		#region String
//		public static string CadenaConexion = @"Data Source=Localhost; Initial Catalog=CryptoWallets; user id=sa; password=Alemania@5792";
//		//public static string CadenaConexion = @"Data Source=localhost; Initial Catalog=CryptoWallets; Integrated Security=SSPI; Persist Security Info=False; User ID=Initial File Name=;Server SPN=";
//		public static string CadenaSelect = "SELECT * FROM Addresses";
//		#endregion

//		#region System
//		#region Byte
//		private System.Byte[] m_PrivateKey;
//		#endregion

//		#region Int32
//		private System.Int32 m_AddressID;
//		private System.Int32 m_WalletID;
//		#endregion

//		#region String
//		private System.String m_PublicKey;
//		#endregion
//		#endregion
//		#endregion
//	}
//	#endregion
//	#endregion
//}
//#endregion
//#endregion
//#endregion
//#endregion
//#endregion
//#endregion