using System.ComponentModel;

namespace PSS.DHPM.CryptoWallet.Desktop.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.gridWallets = new DataGridView();
			this.btnAddWallet = new Button();
			this.btnRefresh = new Button();

			// Grid
			this.gridWallets.Dock = DockStyle.Fill;
			this.gridWallets.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			// Buttons
			this.btnAddWallet.Text = "Add Wallet";
			this.btnAddWallet.Click += new EventHandler(btnAddWallet_Click);
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.Click += new EventHandler(btnRefresh_Click);

			// ToolStrip for buttons
			var toolStrip = new ToolStrip();
			toolStrip.Items.Add(new ToolStripButton("Add Wallet", null,
				btnAddWallet_Click));
			toolStrip.Items.Add(new ToolStripButton("Refresh", null,
				btnRefresh_Click));

			// Form
			this.Size = new Size(800, 600);
			this.Text = "CryptoWallet Manager";

			var container = new Container();
			container.Dock = DockStyle.Fill;
			container.Controls.Add(gridWallets);

			this.Controls.AddRange(new Control[] { toolStrip, container });
		}
		private DataGridView gridWallets;
		private Button btnAddWallet;
		private Button btnRefresh;
		#endregion
	}
}