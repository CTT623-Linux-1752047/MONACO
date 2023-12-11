using MONACO_ASP.Infracstructures;
using System.Threading.Tasks;

namespace MONACO_ASP.Data
{
    public interface IQueryRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }

        Task<TEntity> QueryFirstOrDefaultAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate, bool includeDeleted = false);

        Task<List<TEntity>> QueryAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate);

    }
}
