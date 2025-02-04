using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Table = PSS.DHPM.CryptoWallets.DataLayer.Tables;
namespace PSS.DHPM.CryptoWallets.UILayer.Addresses
{
	public partial class frmAddresses : Form
	{
		public frmAddresses()
		{
			InitializeComponent();
		}
		private Table.Addresses mClaseTabla;
		private Table.Addresses NuevaClaseTabla()
		{
			return new Table.Addresses();
		}
		private ListViewItem lviActual;
		private DataTable dt;
		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			int j = Convert.ToInt32(txtDesde.Text);
			if (j < 0)
			{
				j = 0;
			}
			if (j > dt.Rows.Count - 1)
			{
				j = dt.Rows.Count - 1;
			}
			int k = Convert.ToInt32(txtHasta.Text);
			if (k < 0)
			{
				k = 0;
			}
			if (k > dt.Rows.Count - 1)
			{
				k = dt.Rows.Count - 1;
			}
			listView1.Items.Clear();
			for (int n = j; n <= k; n++)
			{
				DataRow r = dt.Rows[n];
				ListViewItem lvi = null;
				for (int i = 0; i <= dt.Columns.Count - 1; i++)
				{
					if (i == 0)
					{
						lvi = listView1.Items.Add(r[i].ToString());
					}
					else
					{
						lvi.SubItems.Add(r[i].ToString());
					}
				}
			}
			//txtCampo_0.Text = "";
			btnNuevo.Enabled = true;
			btnBorrar.Enabled = false;
			btnActualizar.Enabled = false;
		}
		private void btnNuevo_Click(object sender, EventArgs e)
		{
			mClaseTabla = NuevaClaseTabla();
			mClaseTabla.AddressID = Convert.ToInt32(txtAddressID.Text);
			mClaseTabla.WalletID = Convert.ToInt32(txtWalletID.Text);
			mClaseTabla.PublicKey = txtPublicKey.Text;
			mClaseTabla.PrivateKey = Encoding.ASCII.GetBytes(txtPrivateKey.Text);
			//for (int i = 0; i <= txtCampos.Length - 1; i++)
			//{
			//	mClaseTabla[i] = txtCampos[i].Text;
			//}
			string s = mClaseTabla.Crear();
			if (s.StartsWith("ERROR"))
			{
				MessageBox.Show(s, "Error al crear uno nuevo");
			}
			else
			{
				lviActual = listView1.Items.Add(mClaseTabla[0].ToString());
				lviActual.SubItems.Add(txtAddressID.Text);
				lviActual.SubItems.Add(txtWalletID.Text);
				lviActual.SubItems.Add(txtPublicKey.Text);
				lviActual.SubItems.Add(txtPrivateKey.Text);
				//for (int i = 1; i <= txtCampos.Length - 1; i++)
				//{
				//	lviActual.SubItems.Add(txtCampos[i].Text);
				//}
			}
		}
		private void btnActualizar_Click(object sender, EventArgs e)
		{
			mClaseTabla = NuevaClaseTabla();
			mClaseTabla.AddressID = Convert.ToInt32(txtAddressID.Text);
			mClaseTabla.WalletID = Convert.ToInt32(txtWalletID.Text);
			mClaseTabla.PublicKey = txtPublicKey.Text;
			mClaseTabla.PrivateKey = Encoding.ASCII.GetBytes(txtPrivateKey.Text);
			//for (int i = 0; i <= txtCampos.Length - 1; i++)
			//{
			//	mClaseTabla[i] = txtCampos[i].Text;
			//}
			string s = mClaseTabla.Actualizar();
			if (s.StartsWith("ERROR"))
			{
				MessageBox.Show(s, "Error al actualizar");
			}
			else
			{
				lviActual.SubItems[0].Text = txtAddressID.Text;
				lviActual.SubItems[1].Text = txtWalletID.Text;
				lviActual.SubItems[2].Text = txtPublicKey.Text;
				lviActual.SubItems[3].Text = txtPrivateKey.Text;
				//for (int i = 1; i <= txtCampos.Length - 1; i++)
				//{
				//	lviActual.SubItems[i].Text = txtCampos[i].Text;
				//}
			}
		}
		private void btnBorrar_Click(object sender, EventArgs e)
		{
			mClaseTabla = NuevaClaseTabla();
			mClaseTabla.AddressID = Convert.ToInt32(txtAddressID.Text);
			mClaseTabla.WalletID = Convert.ToInt32(txtWalletID.Text);
			mClaseTabla.PublicKey = txtPublicKey.Text;
			mClaseTabla.PrivateKey = Encoding.ASCII.GetBytes(txtPublicKey.Text);
			//for (int i = 0; i <= txtCampos.Length - 1; i++)
			//{
			//	mClaseTabla[i] = txtCampos[i].Text;
			//}
			string s = mClaseTabla.Borrar();
			if (s.StartsWith("ERROR"))
			{
				MessageBox.Show(s, "Error al borrar");
			}
			else
			{
				listView1.Items.Remove(lviActual);
				lviActual = null;
			}
			btnBorrar.Enabled = false;
		}
		private void btnLimpiar_Click(object sender, EventArgs e)
		{
		}
		private void frmAddresses_Load(object sender, EventArgs e)
		{
			this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
			//txtSelect.Text = Addresses.CadenaSelect;
			listView1.View = View.Details;
			listView1.FullRowSelect = true;
			listView1.LabelEdit = false;
			listView1.GridLines = true;
			listView1.Columns.Clear();
			btnBorrar.Enabled = false;
			btnActualizar.Enabled = false;
			btnNuevo.Enabled = false;
			//btnMostrar_Click(null, null);
			//txtCampo_0.Text = "Creando...";
			//txtCampo_0.Refresh();
			listView1.Columns.Clear();
			dt = Table.Addresses.Tabla(Table.Addresses.CadenaSelect);
			//crearCampos(dt.Columns);
			lblRegsMostrar.Text = "Regs a mostrar" + "\n\r" + "De 0" + "\n\r" + "A " + (dt.Rows.Count - 1);
			txtDesde.Text = "0";
			if (dt.Rows.Count < 101)
			{
				txtHasta.Text = (dt.Rows.Count - 1).ToString();
			}
			else
			{
				txtHasta.Text = "99+";
			}
			foreach (DataColumn col in dt.Columns)
			{
				if (col.DataType.ToString().StartsWith("System.Int"))
				{
					listView1.Columns.Add(col.ColumnName, 60, HorizontalAlignment.Right);
				}
				else if (col.DataType.ToString().StartsWith("System.Date"))
				{
					listView1.Columns.Add(col.ColumnName, 120, HorizontalAlignment.Left);
				}
				else
				{
					listView1.Columns.Add(col.ColumnName, 100, HorizontalAlignment.Left);
				}
			}
			btnRefrescar_Click(sender, EventArgs.Empty);
		}
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				lviActual = listView1.SelectedItems[0];
				txtAddressID.Text = lviActual.SubItems[0].Text;
				txtWalletID.Text = lviActual.SubItems[1].Text;
				txtPublicKey.Text = lviActual.SubItems[2].Text;
				txtPrivateKey.Text = lviActual.SubItems[3].Text;
				//for (int i = 0; i <= lviActual.SubItems.Count - 1; i++)
				//{
				//	txtCampos[i].Text = lviActual.SubItems[i].Text;
				//}
				btnBorrar.Enabled = true;
				btnActualizar.Enabled = true;
			}
		}
	}
}