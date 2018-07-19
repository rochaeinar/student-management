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
    public sealed class StudentStorage : Storage<Student>
    {
        /// <summary>
        /// The padlock
        /// </summary>
        private static readonly object Lock = new object();

        /// <summary>
        /// The instance
        /// </summary>
        private static volatile StudentStorage instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static StudentStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Lock)
                    {
                        if (instance == null)
                            instance = new StudentStorage();
                    }
                }

                return instance;
            }
        }

    }
}