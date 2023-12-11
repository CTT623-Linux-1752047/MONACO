using Microsoft.AspNetCore.Mvc;
using MONACO_ASP.Services.Brands;

namespace MONACO_ASP.Controllers
{
	public class ProductsController : Controller
	{

		private readonly IBrandService _brandService;

		private const String SCREEN_NAME_MEN = "Men";

		private const String SCREEN_NAME_WOMEN = "Women";

		private const String SCREEN_NAME_GIFT = "Giftset";

		private const String SCREEN_NAME_NICHE = "Niche";

		public ProductsController(
			IBrandService brandService) {
			_brandService = brandService;
		}
		public IActionResult Index(string collections)
		{
			switch(collections)
			{
				case "Men": ViewData["ScreenName"] = SCREEN_NAME_MEN; break;
				case "Women": ViewData["ScreenName"] = SCREEN_NAME_WOMEN; break;
				case "Giftset": ViewData["ScreenName"] = SCREEN_NAME_GIFT; break;
				case "Niche": ViewData["ScreenName"] = SCREEN_NAME_NICHE; break;
			}
			

			ViewData["Brands"] = _brandService.GetAllBrands();
			return View();
		}
	}
}
