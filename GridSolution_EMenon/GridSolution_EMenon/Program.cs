using GridSolution_EMenon.Builders;
using GridSolution_EMenon.Models;
using GridSolution_EMenon.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GridSolution_EMenon
{
    public class Program
    {
        /* ASSUMPTIONS:
         *  - input is in a valid format (aka comma separated doubles w/new lines)
         *  - file path input is always valid
         *  - inputted points never have more than one decimal place
         *  - there will always be at least 2 rows and 2 columns
		 * 
		 * - adding test line here
         */
        public static void Main()
        {
            Console.WriteLine("Input filename here (with full filepath): ");

            var filePath = Console.ReadLine();

            string[] inputStrings;

            List<Point> inputs = new List<Point>();

            if (File.Exists(filePath))
            {
                inputStrings = File.ReadAllLines(filePath);

                foreach(var line in inputStrings)
                {
                    var coord = line.Split(',');

                    double.TryParse(coord[0], out double x);
                    double.TryParse(coord[1], out double y);

                    inputs.Add(new Point(x, y));
                }
            }

            var sortedPoints = inputs.OrderByDescending(p => p.Y).ThenByDescending(c => c.X).ToList();

            var rowColCount = (int) Math.Sqrt(inputs.Count); // will always be whole since grid is always square with n rows, n columns

            // rows
            var sortedRows = sortedPoints.SortRows();
            var sortedRowOutput = new RowPointStringBuilder(sortedRows).BuildPointStringOutput(rowColCount);
            Console.WriteLine(sortedRowOutput);

            //columns
            var sortedColumns = sortedRows.SortColumns(rowColCount);
            var sortedColOutput = new ColumnPointStringBuilder(sortedColumns).BuildPointStringOutput(rowColCount);
            Console.WriteLine(sortedColOutput);

            //alpha
            var firstRowPoint = sortedPoints.FirstOrDefault();//sortedRows.FirstOrDefault();
            var adjacentPoint = sortedPoints.ElementAt(1);//sortedRows.ElementAt(1);
            var alphaCalculator = new AlphaCalculator(firstRowPoint, adjacentPoint);
            Console.WriteLine($"Alpha: {alphaCalculator.CalculateAlpha()} degrees");

            Console.WriteLine("\nPress any key to close the console.");
            Console.ReadKey(true);
        }
    }
}
