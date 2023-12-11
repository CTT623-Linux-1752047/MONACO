using Microsoft.AspNetCore.Mvc;
using MONACO_ASP.Services.Brands;

namespace MONACO_ASP.Controllers
{
public class BrandsController : Controller
	{
		private readonly IBrandService _brandService;

		private const String SCREEN_NAME = "Brand";

		public BrandsController(
			IBrandService brandService)
		{
			_brandService = brandService;
		}

        public async Task<IActionResult> Index()
        {
			ViewData["ScreenName"] = SCREEN_NAME;

			var brands = await _brandService.GetAllBrands();

            return View(brands);
        }
    }
}
