using MONACO_ASP.Data;
using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Brands.Imp
{
    public class BrandService : IBrandService
    {
        private readonly IQueryRepository<Brand> _userQuery;

        public BrandService(IQueryRepository<Brand> userQuery)
        {
            _userQuery = userQuery;
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            var query = from brands in _userQuery.Table
                        select brands;
            
            List<Brand> brandsList = new List<Brand>();
            var brand = query.ToList();
            foreach (var item in brand)
            {
                brandsList.Add(item);
            }

            return brandsList;
        }
    }
}
