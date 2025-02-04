using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSS.DHPM.CryptoWallet.API.Models.Requests;

namespace PSS.DHPM.CryptoWallet.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class WalletsController : ControllerBase
	{
		private readonly IWalletService _walletService;
		private readonly IMapper _mapper;
		public WalletsController(IWalletService walletService, IMapper mapper)
		{
			_walletService = walletService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<WalletDto>>> GetWallets()
		{
			var userId = User.GetUserId();
			var wallets = await _walletService.GetUserWalletsAsync(userId);
			return Ok(wallets);
		}
		[HttpPost]
		public async Task<ActionResult<WalletDto>> CreateWallet([FromBody] WalletRequest request)
		{
			var userId = User.GetUserId();
			var wallet = await _walletService.CreateWalletAsync(userId, request);
			return CreatedAtAction(nameof(GetWallet), new
			{
				id = wallet.WalletId
			}, wallet);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<WalletDto>> GetWallet(int id)
		{
			var userId = User.GetUserId();
			var wallet = await _walletService.GetWalletAsync(userId, id);
			if (wallet == null)
			{
				return NotFound();
			}
			return Ok(wallet);
		}
	}
}