namespace BusinessLayer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DataAccessLayer;
    using Models;
    using System.Linq.Expressions;

    /// <summary>
    /// Business logic
    /// </summary>
    public class StudentLogic : IBusinessLogic
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(IEntity entity)
        {
            StudentStorage.Instance.Add((Student)entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            StudentStorage.Instance.Delete(id);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        public void Update(int id, IEntity entity)
        {
            StudentStorage.Instance.Update(id, (Student)entity);
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public IList<IEntity> Get(IDictionary<string, object> filters, Type systemType)
        {
            string propertyToSort = (filters.Keys.Contains("Name") || filters.Keys.Count == 0) ? "Name" : "Date";
            var datasource = StudentStorage.Instance.Get(filters, systemType);
            var param = Expression.Parameter(typeof(Student));
            var getter = Expression.Property(param, propertyToSort);
            var lambda = Expression.Lambda<Func<Student, dynamic>>(getter, param).Compile();
            if (propertyToSort == "Date")
            {
                return datasource.OrderByDescending(lambda).Cast<IEntity>().ToList();
            }
            else
            {
                return datasource.OrderBy(lambda).Cast<IEntity>().ToList();
            }
        }
    }
}