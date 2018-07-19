namespace DataAccessLayer
{
    using System.Collections.Generic;
    using Models;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System;

    /// <summary>
    /// Simulate Storage, will be replaced by a DB
    /// </summary>
    public abstract class Storage<T>
    {
        /// <summary>
        /// The entities
        /// </summary>
        private List<T> entities;

        /// <summary>
        /// Prevents a default instance of the <see cref="Storage"/> class from being created.
        /// </summary>
        public Storage()
        {
            this.entities = new List<T>();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(T entity)
        {
            //entity.Id = this.entities.Count;
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
        public IList<T> Get(IDictionary<string, object> filters, Type systemType)
        {
            IList<T> datasource = null;
            ParameterExpression parameter = Expression.Parameter(systemType, "IEntity");
            MethodInfo containsMethod = typeof(String).GetMethod("Contains", new Type[] { typeof(String) });
            MethodInfo equalsMethod = typeof(object).GetMethod("Equals", new Type[] { typeof(object) });
            Expression dynamicLambda = null;
            MethodCallExpression call = null;
            foreach (string propertyName in filters.Keys)
            {
                PropertyInfo property = systemType.GetProperty(propertyName);
                if (null != property)
                {
                    MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    if (propertyAccess.Type == typeof(string))
                    {
                        call = Expression.Call(propertyAccess, containsMethod, Expression.Constant(filters[propertyName]));
                    }
                    else
                    {
                        call = Expression.Call(propertyAccess, equalsMethod, Expression.Constant(filters[propertyName].ToString()));
                    }
                    
                    if (null == dynamicLambda)
                    {
                        dynamicLambda = call;
                    }
                    else
                    {
                        dynamicLambda = Expression.Or(dynamicLambda, call);
                    }
                }
            }
            if (null != dynamicLambda)
            {
                Expression<Func<T, bool>> predicate = Expression.Lambda<Func<T, bool>>(dynamicLambda, parameter);
                Func<T, bool> compiled = predicate.Compile();
                datasource = entities.AsQueryable().Where(compiled).ToList<T>();
            }
            return datasource;
        }
    }
}