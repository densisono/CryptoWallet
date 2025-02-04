namespace PSS.DHPM.CryptoWallets.UILayer.Addresses
{
	partial class frmAddresses
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
			this.lblRegsMostrar = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.btnBorrar = new System.Windows.Forms.Button();
			this.btnActualizar = new System.Windows.Forms.Button();
			this.btnNuevo = new System.Windows.Forms.Button();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.txtHasta = new System.Windows.Forms.TextBox();
			this.txtDesde = new System.Windows.Forms.TextBox();
			this.lblAddressID = new System.Windows.Forms.Label();
			this.txtAddressID = new System.Windows.Forms.TextBox();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.txtWalletID = new System.Windows.Forms.TextBox();
			this.lblWalletID = new System.Windows.Forms.Label();
			this.txtPublicKey = new System.Windows.Forms.TextBox();
			this.lblPublicKey = new System.Windows.Forms.Label();
			this.txtPrivateKey = new System.Windows.Forms.TextBox();
			this.lblPrivateKey = new System.Windows.Forms.Label();
			this.cboWallet = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblRegsMostrar
			// 
			this.lblRegsMostrar.Location = new System.Drawing.Point(688, 12);
			this.lblRegsMostrar.Name = "lblRegsMostrar";
			this.lblRegsMostrar.Size = new System.Drawing.Size(100, 60);
			this.lblRegsMostrar.TabIndex = 4;
			this.lblRegsMostrar.Text = "Regs a Mostrar";
			// 
			// listView1
			// 
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(9, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(673, 225);
			this.listView1.TabIndex = 19;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// btnBorrar
			// 
			this.btnBorrar.Location = new System.Drawing.Point(688, 214);
			this.btnBorrar.Name = "btnBorrar";
			this.btnBorrar.Size = new System.Drawing.Size(100, 23);
			this.btnBorrar.TabIndex = 18;
			this.btnBorrar.Text = "&Borrar";
			this.btnBorrar.UseVisualStyleBackColor = true;
			this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
			// 
			// btnActualizar
			// 
			this.btnActualizar.Location = new System.Drawing.Point(688, 185);
			this.btnActualizar.Name = "btnActualizar";
			this.btnActualizar.Size = new System.Drawing.Size(100, 23);
			this.btnActualizar.TabIndex = 17;
			this.btnActualizar.Text = "&Actualizar";
			this.btnActualizar.UseVisualStyleBackColor = true;
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			// 
			// btnNuevo
			// 
			this.btnNuevo.Location = new System.Drawing.Point(688, 156);
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(100, 23);
			this.btnNuevo.TabIndex = 16;
			this.btnNuevo.Text = "&Nuevo";
			this.btnNuevo.UseVisualStyleBackColor = true;
			this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
			// 
			// btnRefrescar
			// 
			this.btnRefrescar.Location = new System.Drawing.Point(688, 127);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(100, 23);
			this.btnRefrescar.TabIndex = 15;
			this.btnRefrescar.Text = "&Refrescar";
			this.btnRefrescar.UseVisualStyleBackColor = true;
			this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
			// 
			// txtHasta
			// 
			this.txtHasta.Location = new System.Drawing.Point(688, 101);
			this.txtHasta.Name = "txtHasta";
			this.txtHasta.Size = new System.Drawing.Size(100, 20);
			this.txtHasta.TabIndex = 14;
			// 
			// txtDesde
			// 
			this.txtDesde.Location = new System.Drawing.Point(688, 75);
			this.txtDesde.Name = "txtDesde";
			this.txtDesde.Size = new System.Drawing.Size(100, 20);
			this.txtDesde.TabIndex = 13;
			// 
			// lblAddressID
			// 
			this.lblAddressID.AutoSize = true;
			this.lblAddressID.Location = new System.Drawing.Point(8, 246);
			this.lblAddressID.Name = "lblAddressID";
			this.lblAddressID.Size = new System.Drawing.Size(68, 13);
			this.lblAddressID.TabIndex = 20;
			this.lblAddressID.Text = "Address ID : ";
			// 
			// txtAddressID
			// 
			this.txtAddressID.Enabled = false;
			this.txtAddressID.Location = new System.Drawing.Point(82, 243);
			this.txtAddressID.Name = "txtAddressID";
			this.txtAddressID.ReadOnly = true;
			this.txtAddressID.Size = new System.Drawing.Size(70, 20);
			this.txtAddressID.TabIndex = 21;
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Location = new System.Drawing.Point(688, 243);
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
			this.btnLimpiar.TabIndex = 22;
			this.btnLimpiar.Text = "&Limpiar";
			this.btnLimpiar.UseVisualStyleBackColor = true;
			this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
			// 
			// txtWalletID
			// 
			this.txtWalletID.Enabled = false;
			this.txtWalletID.Location = new System.Drawing.Point(82, 269);
			this.txtWalletID.Name = "txtWalletID";
			this.txtWalletID.ReadOnly = true;
			this.txtWalletID.Size = new System.Drawing.Size(70, 20);
			this.txtWalletID.TabIndex = 24;
			// 
			// lblWalletID
			// 
			this.lblWalletID.AutoSize = true;
			this.lblWalletID.Location = new System.Drawing.Point(16, 272);
			this.lblWalletID.Name = "lblWalletID";
			this.lblWalletID.Size = new System.Drawing.Size(60, 13);
			this.lblWalletID.TabIndex = 23;
			this.lblWalletID.Text = "Wallet ID : ";
			// 
			// txtPublicKey
			// 
			this.txtPublicKey.Enabled = false;
			this.txtPublicKey.Location = new System.Drawing.Point(82, 295);
			this.txtPublicKey.Name = "txtPublicKey";
			this.txtPublicKey.ReadOnly = true;
			this.txtPublicKey.Size = new System.Drawing.Size(463, 20);
			this.txtPublicKey.TabIndex = 26;
			// 
			// lblPublicKey
			// 
			this.lblPublicKey.AutoSize = true;
			this.lblPublicKey.Location = new System.Drawing.Point(10, 298);
			this.lblPublicKey.Name = "lblPublicKey";
			this.lblPublicKey.Size = new System.Drawing.Size(66, 13);
			this.lblPublicKey.TabIndex = 25;
			this.lblPublicKey.Text = "Public Key : ";
			// 
			// txtPrivateKey
			// 
			this.txtPrivateKey.Enabled = false;
			this.txtPrivateKey.Location = new System.Drawing.Point(82, 321);
			this.txtPrivateKey.Name = "txtPrivateKey";
			this.txtPrivateKey.ReadOnly = true;
			this.txtPrivateKey.Size = new System.Drawing.Size(463, 20);
			this.txtPrivateKey.TabIndex = 28;
			// 
			// lblPrivateKey
			// 
			this.lblPrivateKey.AutoSize = true;
			this.lblPrivateKey.Location = new System.Drawing.Point(6, 324);
			this.lblPrivateKey.Name = "lblPrivateKey";
			this.lblPrivateKey.Size = new System.Drawing.Size(70, 13);
			this.lblPrivateKey.TabIndex = 27;
			this.lblPrivateKey.Text = "Private Key : ";
			// 
			// cboWallet
			// 
			this.cboWallet.Enabled = false;
			this.cboWallet.FormattingEnabled = true;
			this.cboWallet.Location = new System.Drawing.Point(158, 268);
			this.cboWallet.Name = "cboWallet";
			this.cboWallet.Size = new System.Drawing.Size(387, 21);
			this.cboWallet.TabIndex = 29;
			// 
			// frmAddresses
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 355);
			this.Controls.Add(this.cboWallet);
			this.Controls.Add(this.txtPrivateKey);
			this.Controls.Add(this.lblPrivateKey);
			this.Controls.Add(this.txtPublicKey);
			this.Controls.Add(this.lblPublicKey);
			this.Controls.Add(this.txtWalletID);
			this.Controls.Add(this.lblWalletID);
			this.Controls.Add(this.btnLimpiar);
			this.Controls.Add(this.txtAddressID);
			this.Controls.Add(this.lblAddressID);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.btnBorrar);
			this.Controls.Add(this.btnActualizar);
			this.Controls.Add(this.btnNuevo);
			this.Controls.Add(this.btnRefrescar);
			this.Controls.Add(this.txtHasta);
			this.Controls.Add(this.txtDesde);
			this.Controls.Add(this.lblRegsMostrar);
			this.Name = "frmAddresses";
			this.Text = "Addresses";
			this.Load += new System.EventHandler(this.frmAddresses_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblRegsMostrar;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnBorrar;
		private System.Windows.Forms.Button btnActualizar;
		private System.Windows.Forms.Button btnNuevo;
		private System.Windows.Forms.Button btnRefrescar;
		private System.Windows.Forms.TextBox txtHasta;
		private System.Windows.Forms.TextBox txtDesde;
		private System.Windows.Forms.Label lblAddressID;
		private System.Windows.Forms.TextBox txtAddressID;
		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.TextBox txtWalletID;
		private System.Windows.Forms.Label lblWalletID;
		private System.Windows.Forms.TextBox txtPublicKey;
		private System.Windows.Forms.Label lblPublicKey;
		private System.Windows.Forms.TextBox txtPrivateKey;
		private System.Windows.Forms.Label lblPrivateKey;
		private System.Windows.Forms.ComboBox cboWallet;
	}
}