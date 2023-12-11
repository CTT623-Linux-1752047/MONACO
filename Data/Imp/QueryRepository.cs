using Microsoft.EntityFrameworkCore;
using MONACO_ASP.Infracstructures;

namespace MONACO_ASP.Data.Imp
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : BaseEntity
    {
        #region Variable
        private readonly AppDbContext dbContext;
        #endregion

        #region Properties
        protected DbSet<TEntity> Entities => dbContext.Set<TEntity>();
        #endregion

        public IQueryable<TEntity> Table => Entities.AsNoTracking();

        public QueryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TEntity> QueryFirstOrDefaultAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate, bool includeDeleted)
        {
            var query = IncludeDeletedFilter(Table, includeDeleted);

            return await (predicate == null ? query : predicate(query)).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate)
        {
            var query = IncludeDeletedFilter(Table, true);

            return await(predicate == null ? query : predicate(query)).ToListAsync();
        }

        private IQueryable<TEntity> IncludeDeletedFilter(IQueryable<TEntity> query, in bool includeDeleted)
        {
            if (includeDeleted) return query;

            if (typeof(TEntity).GetInterface(nameof(ISoftDeleteEntity)) == null)
                return query;

            return query.OfType<ISoftDeleteEntity>().Where(entry => entry.IsDeleted == false).OfType<TEntity>();
        }
    }
}
