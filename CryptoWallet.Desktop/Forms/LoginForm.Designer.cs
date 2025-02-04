namespace PSS.DHPM.CryptoWallet.Desktop.Forms
{
	partial class LoginForm
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
			this.txtEmail = new TextBox();
			this.txtPassword = new TextBox();
			this.btnLogin = new Button();
			this.lblEmail = new Label();
			this.lblPassword = new Label();

			// Email
			this.lblEmail.Text = "Email:";
			this.lblEmail.Location = new Point(20, 20);
			this.txtEmail.Location = new Point(20, 40);
			this.txtEmail.Size = new Size(200, 20);

			// Password
			this.lblPassword.Text = "Password:";
			this.lblPassword.Location = new Point(20, 70);
			this.txtPassword.Location = new Point(20, 90);
			this.txtPassword.Size = new Size(200, 20);
			this.txtPassword.PasswordChar = '*';

			// Login button
			this.btnLogin.Text = "Login";
			this.btnLogin.Location = new Point(20, 130);
			this.btnLogin.Click += new EventHandler(btnLogin_Click);

			// Form
			this.ClientSize = new Size(240, 180);
			this.Controls.AddRange(new Control[] {
			this.lblEmail, this.txtEmail,
			this.lblPassword, this.txtPassword,
			this.btnLogin
		});
			this.Text = "Login";
			this.StartPosition = FormStartPosition.CenterScreen;
		}
		private TextBox txtEmail;
		private TextBox txtPassword;
		private Button btnLogin;
		private Label lblEmail;
		private Label lblPassword;
		#endregion
	}
}