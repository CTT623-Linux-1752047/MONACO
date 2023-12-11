using MONACO_ASP.Entities;

namespace MONACO_ASP.Services.Brands
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllBrands();
    }
}
