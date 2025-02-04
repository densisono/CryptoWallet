using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSS.DHPM.CryptoWallet.Desktop.Forms
{
	public partial class MainForm : Form
	{
		private readonly IApiService _apiService;
		public MainForm(IApiService apiService)
		{
			_apiService = apiService;
			InitializeComponent();
		}
		protected override async void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			await LoadWallets();
		}
		private async Task LoadWallets()
		{
			try
			{
				var wallets = await _apiService.GetWalletsAsync();
				gridWallets.DataSource = wallets;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void btnAddWallet_Click(object sender, EventArgs e)
		{
			using (var form = new WalletForm(_apiService))
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadWallets();
				}
			}
		}
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadWallets();
		}
	}
}