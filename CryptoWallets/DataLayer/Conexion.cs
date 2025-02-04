#region Using
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

#region Linq
using System.Linq;
#endregion

#region Text
using System.Text;
#endregion

#region Threading
#region Tasks
using System.Threading.Tasks;
#endregion
#endregion
#endregion
#endregion

#region Namespace
#region PSS
#region DHPM
#region CryptoWallets
#region DataLayer
namespace PSS.DHPM.CryptoWallets.DataLayer
{
	#region Class
	#region Conexion
	internal class Conexion
	{
		#region Functions
		#region SqlConnection
		#region CloseConexion
		#region ()
		public SqlConnection CloseConexion()
		{
			if (conexion.State == ConnectionState.Open)
			{
				conexion.Close();
			}

			return conexion;
		}
		#endregion
		#endregion

		#region OpenConexion
		#region ()
		public SqlConnection OpenConexion()
		{
			if (conexion.State == ConnectionState.Closed)
			{
				conexion.Open();
			}

			return conexion;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Variables
		#region SqlConnection
		private SqlConnection conexion = new SqlConnection("Server=DESKTOP-MDE3BK6;Database=CryptoWallets;Persist Security Info=False;User ID=sa;Password=Alemania@5792");
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