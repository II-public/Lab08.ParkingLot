using System;
using System.Linq;
using System.Linq.Expressions;
using Lab08.ParkingLot.Data.Context;
using Lab08.ParkingLot.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab08.ParkingLot.Repository
{
    /// <summary>
    /// Repository base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected ParkingLotDBContext DataContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public RepositoryBase(ParkingLotDBContext dataContext)
        {
            DataContext = dataContext;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return DataContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Gets the by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return DataContext.Set<T>().Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            DataContext.Set<T>().Update(entity);
        }

        /// <summary>
        /// Gets all with include.
        /// </summary>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            var queryable = (IQueryable<T>)GetAll();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }
    }
}
