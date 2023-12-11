using MONACO_ASP.Data;
using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Categories.Imp
{
    public class CategoryService : ICategoryService
    {
        private readonly IQueryRepository<Category> _userQuery;

        public CategoryService(IQueryRepository<Category> userQuery)
        {
            _userQuery = userQuery;
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            //var categories = await _userQuery.QueryAsync((query) =>
            //{
            //    return from categories in query
            //           select categories;
            //});

            var query = from categories in _userQuery.Table 
                        select  categories;

            IList<Category> categoriesList = new List<Category>();
            var categorie = query.ToList();
            foreach (var category in categorie)
            {
                categoriesList.Add(category);
            }
            return categoriesList;
        }
    }
}
