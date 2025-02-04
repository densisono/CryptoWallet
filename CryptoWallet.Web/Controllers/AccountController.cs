using Microsoft.AspNetCore.Mvc;
using PSS.DHPM.CryptoWallet.Web.Models.ViewModels;

namespace PSS.DHPM.CryptoWallet.Web.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAuthService _authService;
		public AccountController(IAuthService authService)
		{
			_authService = authService;
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _authService.LoginAsync(model.Email, model.Password);
			if (!result.Success)
			{
				ModelState.AddModelError(string.Empty, result.Message);
				return View(model);
			}
			HttpContext.Session.SetString("Token", result.Token);
			return RedirectToAction("Index", "Home");
		}
	}
}