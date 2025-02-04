using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS.DHPM.CryptoWallet.Desktop.Forms
{
	public partial class LoginForm : Form
	{
		private readonly IApiService _apiService;
		public LoginForm(IApiService apiService)
		{
			InitializeComponent();
			_apiService = apiService;
		}
		private async void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				var result = await _apiService.LoginAsync(txtEmail.Text, txtPassword.Text);
				if (result.Success)
				{
					_apiService.SetToken(result.Token);
					DialogResult = DialogResult.OK;
				}
				else
				{
					MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}