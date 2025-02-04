using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Tabla = PSS.DHPM.CryptoWallets.DataLayer.Tables;
namespace PSS.DHPM.CryptoWallets.UILayer
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		//public static void Main()
		//{
		//	Application.Run(new Form1());
		//}
		private Tabla.Addresses mClaseTabla;
		private Tabla.Addresses nuevaClaseTabla()
		{
			return new Tabla.Addresses();
		}
		private Label[] labelCampos;
		private TextBox[] txtCampos;
		private ListViewItem lviActual;
		private DataTable dt;
		private void crearCampos(DataColumnCollection cols)
		{
			int k;
			int n = cols.Count;
			if (labelCampos != null)
			{
				for (int i = 1; i <= labelCampos.Length - 1; i++)
				{
					this.Controls.Remove(labelCampos[i]);
				}
			}
			if (txtCampos != null)
			{
				for (int i = 1; i <= txtCampos.Length - 1; i++)
				{
					this.Controls.Remove(txtCampos[i]);
				}
			}
			this.AutoScroll = false;
			labelCampos = new Label[(n - 1 + 1)];
			txtCampos = new TextBox[(n - 1 + 1)];
			labelCampos[0] = lblCampo_0;
			txtCampo_0.Enabled = true;
			txtCampos[0] = txtCampo_0;
			k = txtCampos[0].TabIndex;
			for (int i = 0; i <= n - 1; i++)
			{
				DataColumn col = cols[i];
				if (i > 0)
				{
					labelCampos[i] = new Label();
					txtCampos[i] = new TextBox();
					k += 1;
					labelCampos[i].TabIndex = k;
					k += 1;
					txtCampos[i].TabIndex = k;
					labelCampos[i].Name = "LabelCampo_" + i.ToString();
					txtCampos[i].Name = "txtCampo_" + i.ToString();
					labelCampos[i].Anchor = labelCampos[0].Anchor;
					txtCampos[i].Anchor = txtCampos[0].Anchor;
					labelCampos[i].Size = labelCampos[0].Size;
					labelCampos[i].Location = labelCampos[i - 1].Location;
					labelCampos[i].Top += 24;
					txtCampos[i].Size = txtCampos[0].Size;
					txtCampos[i].Location = txtCampos[i - 1].Location;
					txtCampos[i].Top += 24;
					labelCampos[i].Visible = true;
					txtCampos[i].Visible = true;
					this.Controls.Add(labelCampos[i]);
					this.Controls.Add(txtCampos[i]);
					txtCampos[i].Text = "";
				}
				labelCampos[i].Text = col.ColumnName + ":";
			}
			n = txtCampos[n - 1].Top + 24 + 36;
			this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, n);
			this.AutoScroll = true;
		}
		private void btnMostrar_Click(System.Object sender, System.EventArgs e)
		{
			txtCampo_0.Text = "Creando...";
			txtCampo_0.Refresh();
			listView1.Columns.Clear();
			dt = Tabla.Addresses.Tabla(txtSelect.Text);
			crearCampos(dt.Columns);
			lblRegsMostrar.Text = "Regs a mostrar" + "\n\r" + "De 0" + "\n\r" + "A " + (dt.Rows.Count - 1);
			txtDesde.Text = "0";
			if (dt.Rows.Count < 101)
			{
				txtHasta.Text = (dt.Rows.Count - 1).ToString();
			}
			else
			{
				txtHasta.Text = "99";
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
		private void btnRefrescar_Click(System.Object sender, System.EventArgs e)
		{
			//int j = Convert.ToInt32(txtDesde.Text);
			//if (j < 0)
			//{
			//	j = 0;
			//}
			//if (j > dt.Rows.Count - 1)
			//{
			//	j = dt.Rows.Count - 1;
			//}
			//int k = Convert.ToInt32(txtHasta.Text);
			//if (k < 0)
			//{
			//	k = 0;
			//}
			//if (k > dt.Rows.Count - 1)
			//{
			//	k = dt.Rows.Count - 1;
			//}
			//listView1.Items.Clear();
			//for (int n = j; n <= k; n++)
			//{
			//	DataRow r = dt.Rows[n];
			//	ListViewItem lvi = null;
			//	for (int i = 0; i <= dt.Columns.Count - 1; i++)
			//	{
			//		if (i == 0)
			//		{
			//			lvi = listView1.Items.Add(r[i].ToString());
			//		}
			//		else
			//		{
			//			lvi.SubItems.Add(r[i].ToString());
			//		}
			//	}
			//}
			//txtCampo_0.Text = "";
			//btnNuevo.Enabled = true;
			//btnBorrar.Enabled = false;
			//btnActualizar.Enabled = false;
			if (dt == null || dt.Rows.Count == 0)
			{
				MessageBox.Show("No hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			int j;
			int k;
			if (!int.TryParse(txtDesde.Text, out j))
			{
				j = 0;
			}
			if (!int.TryParse(txtHasta.Text, out k))
			{
				k = 0;
			}
			j = Math.Max(0, Math.Min(j, dt.Rows.Count - 1));
			k = Math.Max(0, Math.Min(k, dt.Rows.Count - 1));
			if (j > k)
			{
				int temp = j;
				j = k;
				k = temp;
			}
			listView1.Items.Clear();
			for (int n = j; n <= k; n++)
			{
				if (n < 0 || n >= dt.Rows.Count)
				{
					continue;
				}
				DataRow r = dt.Rows[n];
				ListViewItem lvi = null;
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					if (i == 0)
					{
						lvi = listView1.Items.Add(r[i].ToString());
					}
					else
					{
						lvi?.SubItems.Add(r[i].ToString());
					}
				}
			}
			txtCampo_0.Text = "";
			btnNuevo.Enabled = true;
			btnBorrar.Enabled = false;
			btnActualizar.Enabled = false;
		}
		private void Form1_Load(System.Object sender, System.EventArgs e)
		{
			this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
			txtSelect.Text = Tabla.Addresses.CadenaSelect;
			listView1.View = View.Details;
			listView1.FullRowSelect = true;
			listView1.LabelEdit = false;
			listView1.GridLines = true;
			listView1.Columns.Clear();
			btnBorrar.Enabled = false;
			btnActualizar.Enabled = false;
			btnNuevo.Enabled = false;
			btnMostrar_Click(null, null);
		}
		private void listView1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				lviActual = listView1.SelectedItems[0];
				for (int i = 0; i <= lviActual.SubItems.Count - 1; i++)
				{
					txtCampos[i].Text = lviActual.SubItems[i].Text;
				}
				btnBorrar.Enabled = true;
				btnActualizar.Enabled = true;
			}
		}
		private void btnNuevo_Click(System.Object sender, System.EventArgs e)
		{
			mClaseTabla = nuevaClaseTabla();
			for (int i = 0; i <= txtCampos.Length - 1; i++)
			{
				mClaseTabla[i] = txtCampos[i].Text;
			}
			string s = mClaseTabla.Crear();
			if (s.StartsWith("ERROR"))
			{
				MessageBox.Show(s, "Error al crear uno nuevo");
			}
			else
			{
				lviActual = listView1.Items.Add(mClaseTabla[0].ToString());
				for (int i = 1; i <= txtCampos.Length - 1; i++)
				{
					lviActual.SubItems.Add(txtCampos[i].Text);
				}
			}
		}
		private void btnActualizar_Click(System.Object sender, System.EventArgs e)
		{
			mClaseTabla = nuevaClaseTabla();
			for (int i = 0; i <= txtCampos.Length - 1; i++)
			{
				mClaseTabla[i] = txtCampos[i].Text;
			}
			string s = mClaseTabla.Actualizar();
			if (s.StartsWith("ERROR"))
			{
				MessageBox.Show(s, "Error al actualizar");
			}
			else
			{
				for (int i = 1; i <= txtCampos.Length - 1; i++)
				{
					lviActual.SubItems[i].Text = txtCampos[i].Text;
				}
			}
		}
		private void btnBorrar_Click(System.Object sender, System.EventArgs e)
		{
			mClaseTabla = nuevaClaseTabla();
			for (int i = 0; i <= txtCampos.Length - 1; i++)
			{
				mClaseTabla[i] = txtCampos[i].Text;
			}
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
	}
}