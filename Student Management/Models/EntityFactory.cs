namespace Models
{
    using System;
    using Common;

    /// <summary>
    /// The Entity factory
    /// </summary>
    public class EntityFactory
    {
        /// <summary>
        /// Creates the entity.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="data">The data.</param>
        /// <returns>IEntity data</returns>
        public static IEntity CreateEntity(EntityType entityType, string[] data)
        {
            IEntity entity = null;

            switch (entityType)
            {
                case EntityType.Student:
                    entity = new Student(data);
                    break;
            }

            return entity;
        }
    }
}