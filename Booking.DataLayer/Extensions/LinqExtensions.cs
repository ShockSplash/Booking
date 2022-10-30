using System.Linq;
using Booking.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataLayer.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Только активные
        /// </summary>
        public static IQueryable<TEntity> OnlyActive<TEntity>(this DbSet<TEntity> dbSet) where TEntity : BaseEntity
        {
            return dbSet.Where(x => x.IsActive);
        }
    }
}