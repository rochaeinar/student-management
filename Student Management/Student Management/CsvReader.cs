namespace Student_Management
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Csv reader
    /// </summary>
    internal class CsvReader
    {
        /// <summary>
        /// The CSV separator
        /// </summary>
        private const char SEPARATOR = ';';

        /// <summary>
        /// Reads the CSV.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>IEnumerable string</returns>
        public static IEnumerable<string[]> ReadCsv(string filename)
        {
            var lines = File.ReadAllLines(filename).Select(a => a.Split(SEPARATOR));
            return lines;
        }
    }
}