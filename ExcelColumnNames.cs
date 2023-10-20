using System;
using System.Collections.Generic;

namespace excelcolumnnames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a function that creates a column label, similar to how Excel labels columns from A-Z, and then continues with AA, AB
            // The idea is to treat this naming scheme as a base 26 numbering format, with the letters of the alphabet as the numeric symbols
            // Then the problem becomes a simple problem of base conversion from base 10 to base 26.
            // Example, "ABC" = 1*26^2 + 2*26^1 + 3*26^0

            // Using a dictionary enables making the solution extensible by adding additional symbols if required
            var columnDictionary = new Dictionary<int, char>()
            {
                {1,'A'},{2,'B'},{3,'C'},{4,'D'},{5,'E'},
                {6,'F'},{7,'G'},{8,'H'},{9,'I'},{10,'J'},
                {11,'K'},{12,'L'},{13,'M'},{14,'N'},{15,'O'},
                {16,'P'},{17,'Q'},{18,'R'},{19,'S'},{20,'T'},
                {21,'U'},{22,'V'},{23,'W'},{24,'X'},{25,'Y'},{26,'Z'}
            };

            int input = 27;

            if (input <= 0)
            {
                throw new ArgumentOutOfRangeException("Must be a positive nunber greater than 0");
            }

            int colNumber = input;
            string colLabel = string.Empty;
            int remainder;
            do
            {
                remainder = colNumber % columnDictionary.Count;
                colNumber = colNumber / columnDictionary.Count;
                colLabel = $"{columnDictionary[remainder]}{colLabel}";
            } while (colNumber > 0);

            Console.WriteLine($"Column number: {input}, Column Label {colLabel}");
        }
    }
}
