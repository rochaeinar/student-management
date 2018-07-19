namespace BusinessLayer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DataAccessLayer;
    using Models;

    /// <summary>
    /// Business logic
    /// </summary>
    public class StudentLogic: IBusinessLogic
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
            return StudentStorage.Instance.Get(filters, systemType).Cast<IEntity>().ToList();
        }
    }
}