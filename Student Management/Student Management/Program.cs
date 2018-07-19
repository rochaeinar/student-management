namespace Student_Management
{
    using System.Collections.Generic;
    using Common;
    using Models;
    using System;

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

            string inputFile = args.Length > 0 && args[0].EndsWith("csv") ? args[0] : "input.csv";

            var lines = CsvReader.ReadCsv(inputFile);
            using (IEnumerator<string[]> linesEnumerator = lines.GetEnumerator())
            {
                while (linesEnumerator.MoveNext())
                {
                    IEntity entity = EntityFactory.CreateEntity(EntityType.Student, linesEnumerator.Current);
                    studentController.Add(entity);
                }
            }

            IDictionary<string, object> dictionary = new Dictionary<string, object>();

            for (var i = 1; i < args.Length; i++)
            {
                string[] nameValuePair = args[i].Split('=');
                dictionary.Add(nameValuePair[0], nameValuePair[1]);
            }

            var data = studentController.Get(dictionary);

            foreach (IEntity student in data)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}