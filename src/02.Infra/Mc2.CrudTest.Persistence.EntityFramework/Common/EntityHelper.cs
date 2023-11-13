using Mc2.CrudTest.Domain.Common;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Persistence.EntityFramework.Common
{
    public class EntityHelper
    {
        public static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId<TEntity, TKey>(TKey id) where TEntity : Entity<TKey>
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity));
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(Expression.PropertyOrField(parameterExpression, "Id"), Expression.Constant(id, typeof(TKey))), new ParameterExpression[1] { parameterExpression });
        }
    }
}
