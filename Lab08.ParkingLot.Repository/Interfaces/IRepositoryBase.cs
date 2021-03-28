using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lab08.ParkingLot.Repository.Interfaces
{
    /// <summary>
    /// repository base interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets all with include.
        /// </summary>
        /// <param name="actions">The actions.</param>
        /// <returns></returns>
        IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] actions);

        /// <summary>
        /// Gets the by condition.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
    }
}
