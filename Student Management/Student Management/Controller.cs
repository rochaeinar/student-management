namespace Student_Management
{
    using BusinessLayer;
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Base Controller 
    /// </summary>
    internal abstract class Controller
    {
        /// <summary>
        /// The system type
        /// </summary>
        private Type systemType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        public Controller()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        public Controller(Type systemType, IBusinessLogic BusinessLogic)
        {
            this.BusinessLogic = BusinessLogic;
            this.systemType = systemType;
        }

        /// <summary>
        /// Gets or sets the business logic.
        /// </summary>
        /// <value>
        /// The business logic.
        /// </value>
        protected IBusinessLogic BusinessLogic { get; set; }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(IEntity entity)
        {
            this.BusinessLogic.Add(entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            this.BusinessLogic.Delete(id);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        public void Update(int id, IEntity entity)
        {
            this.BusinessLogic.Update(id, entity);
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public IList<IEntity> Get(IDictionary<string, object> filters)
        {
            return this.BusinessLogic.Get(filters, this.systemType);
        }
    }
}