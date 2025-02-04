using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSS.DHPM.CryptoWallet.Web.Models.ViewModels;

namespace PSS.DHPM.CryptoWallet.Web.Controllers
{
	[Authorize]
	public class WalletController : Controller
	{
		private readonly IWalletService _walletService;
		public WalletController(IWalletService walletService)
		{
			_walletService = walletService;
		}
		public async Task<IActionResult> Index()
		{
			var userId = User.GetUserId();
			var wallets = await _walletService.GetUserWalletsAsync(userId);
			return View(wallets);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(WalletViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var userId = User.GetUserId();
			var request = new WalletRequest
			{
				Name = model.Name,
				WalletTypeId = model.WalletTypeId
			};
			await _walletService.CreateWalletAsync(userId, request);
			return RedirectToAction(nameof(Index));
		}
	}
}