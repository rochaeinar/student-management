namespace Models
{
    using System;
    using Common;

    /// <summary>
    /// Student entity
    /// </summary>
    /// <seealso cref="Models.IEntity" />
    public class Student : IEntity
    {
        /// <summary>
        /// The date format
        /// </summary>
        private const string FORMAT = "yyyyMMddHHmmss";

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public Student(string[] data)
        {
            this.Type = (StudentType)Enum.Parse(typeof(StudentType), data[0], true);
            this.Name = data[1];
            this.Gender = (Gender)Enum.Parse(typeof(Gender), data[2], true);
            this.Date = DateTime.ParseExact(data[3], FORMAT, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public StudentType Type { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public Gender Gender { get; set; }
    }
}