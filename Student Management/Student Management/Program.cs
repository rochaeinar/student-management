namespace Student_Management
{
    using System.Collections.Generic;
    using Common;
    using Models;

    /// <summary>
    /// Main Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            StudentController studentController = new StudentController();
            var lines = CsvReader.ReadCsv("input.csv");
            using (IEnumerator<string[]> linesEnumerator = lines.GetEnumerator())
            {
                while (linesEnumerator.MoveNext())
                {
                    IEntity entity = EntityFactory.CreateEntity(EntityType.Student, linesEnumerator.Current);
                    studentController.Add(entity);
                }
            }

            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("Name", "Emma");
            dictionary.Add("Gender", "F");
            var data = studentController.Get(dictionary);
        }
    }
}