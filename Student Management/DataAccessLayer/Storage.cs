namespace DataAccessLayer
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Simulate Storage, will be replaced by a DB
    /// </summary>
    public sealed class Storage
    {
        /// <summary>
        /// The padlock
        /// </summary>
        private static readonly object Padlock = new object();

        /// <summary>
        /// The instance
        /// </summary>
        private static volatile Storage instance = null;

        /// <summary>
        /// The entities
        /// </summary>
        private List<IEntity> entities;

        /// <summary>
        /// Prevents a default instance of the <see cref="Storage"/> class from being created.
        /// </summary>
        private Storage()
        {
            this.entities = new List<IEntity>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Storage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Padlock)
                    {
                        if (instance == null)
                            instance = new Storage();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(IEntity entity)
        {
            entity.Id = this.entities.Count;
            this.entities.Add(entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        public void Update(int id, IEntity entity)
        {
            
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Get(IEntity entity)
        {
            
        }
    }
}