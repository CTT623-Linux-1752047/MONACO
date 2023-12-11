using Microsoft.AspNetCore.Mvc;
using MONACO_ASP.Services.Categories;

namespace MONACO_ASP.Components
{
	[ViewComponent]
	public class MenuCategoriesViewComponent : ViewComponent
	{
        private readonly ICategoryService _categoryService;

        public MenuCategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var categories = await _categoryService.GetAllCategories();
			return View(categories);
		}
	}
}
