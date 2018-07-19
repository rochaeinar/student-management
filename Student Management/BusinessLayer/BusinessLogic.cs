namespace BusinessLayer
{
    using DataAccessLayer;
    using Models;

    /// <summary>
    /// Business logic
    /// </summary>
    public class BusinessLogic
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(IEntity entity)
        {
            Storage.Instance.Add(entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            Storage.Instance.Delete(id);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        public void Update(int id, IEntity entity)
        {
            Storage.Instance.Update(id, entity);
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Get(IEntity entity)
        {
            Storage.Instance.Get(entity);
        }
    }
}