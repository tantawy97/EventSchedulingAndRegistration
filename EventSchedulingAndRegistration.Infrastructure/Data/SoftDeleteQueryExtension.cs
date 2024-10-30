using EventSchedulingAndRegistration.Domain.Abstract;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace EventSchedulingAndRegistration.Infrastructure.Data
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(entityData.ClrType);
            object? filter = methodToCall?.Invoke(null, []);
            entityData.SetQueryFilter((LambdaExpression)filter!);
            entityData.AddIndex(entityData.FindProperty(nameof(ISoftDeletedEntity.IsDeleted))!);
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, ISoftDeletedEntity
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }
}
