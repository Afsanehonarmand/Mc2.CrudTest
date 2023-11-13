using Mc2.CrudTest.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Persistence.EntityFramework.Common
{
    public abstract class RepositoryBase<TEntity, TKey> where TEntity : AggregateRoot<TKey> where TKey : IEquatable<TKey>
    {
        protected DbContext Context;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBase(DbContext context)
        {
            DbSet = context.Set<TEntity>();
            Context = context;
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await DbSet.CountAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetQuery().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetQuery().Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await GetQuery().ToListAsync(cancellationToken);
        }

        public virtual async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetQuery().AnyAsync(predicate, cancellationToken);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        protected virtual IQueryable<TEntity> GetQuery()
        {
            IQueryable<TEntity> queryable = DbSet.AsQueryable();
            IList<Expression<Func<TEntity, object>>> includes = GetIncludes();
            if (includes != null && includes.Any())
            {
                foreach (Expression<Func<TEntity, object>> item in includes)
                {
                    if (item.Body.NodeType == ExpressionType.Constant)
                    {
                        ConstantExpression constantExpression = item.Body as ConstantExpression;
                        queryable = queryable.Include(constantExpression.Value!.ToString());
                    }
                    else
                    {
                        queryable = queryable.Include(item);
                    }
                }

                return queryable;
            }

            return queryable;
        }

        protected abstract IList<Expression<Func<TEntity, object?>>> GetIncludes();

        public virtual async Task<PagedCollectionQueryResult<TEntity>> GetPaginatedListAsync(
        int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            IQueryable<TEntity> query = GetQuery().Where(predicate);

            int totalCount = await query.CountAsync(cancellationToken);

            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else if (pageNumber > totalPages)
            {
                pageNumber = totalPages;
            }

            int skip = (pageNumber - 1) * pageSize;

            List<TEntity> items = await query.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);

            return new PagedCollectionQueryResult<TEntity>(pageNumber,pageSize,totalPages,items);
        }


    }

}
