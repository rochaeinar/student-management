using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessLogic
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(IEntity entity);


        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        void Update(int id, IEntity entity);

        /// <summary>
        /// Gets the specified filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <returns></returns>
        IList<IEntity> Get(IDictionary<string, object> filters, Type systemType);
    }
}
