using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Categories
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAllCategories();
    }
}
