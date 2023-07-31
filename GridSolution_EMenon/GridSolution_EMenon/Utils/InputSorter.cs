using GridSolution_EMenon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridSolution_EMenon.Utils
{
    public static class InputSorter
    {
        public static IEnumerable<Point> SortRows(this IEnumerable<Point> points)
        {
            var sortedPoints = points.ToList();
            var rowColCount = (int)Math.Sqrt(points.Count()); // will always be whole since grid is always square with n rows, n columns

            var highestY = sortedPoints.First();
            var nextPoint = sortedPoints.ElementAt(1);

            var sortedRows = new List<Point>();

            //determine orientation of grid
            if (nextPoint.X > highestY.X) // grid leans to the right/rotated 45 degrees from x-axis
            {
                var currPoint = highestY;
                sortedRows.Add(highestY);
                sortedPoints.Remove(highestY);
                var rowCount1 = 1;
                var idx = 0;

                while (sortedPoints.Count > 0)
                {
                    nextPoint = sortedPoints.ElementAt(idx);
                    if (nextPoint.X > currPoint.X)
                    {
                        sortedRows.Add(nextPoint);
                        currPoint = nextPoint;

                        sortedPoints.Remove(nextPoint);
                        rowCount1++;
                        idx = 0;
                    }

                    else
                    {
                        if (rowCount1 == rowColCount)
                        {
                            rowCount1 = 1;
                            currPoint = sortedPoints.FirstOrDefault();
                            sortedRows.Add(currPoint);
                            sortedPoints.Remove(currPoint);
                            idx = 0;
                        }
                        else
                        {
                            idx++;
                        }
                    }
                }
            }

            else // grid leans to the left or is parallel to x-axis
            {
                var rowCount = 1;

                while (sortedPoints.Count > 0)
                {
                    if (rowCount > rowColCount)
                    {
                        rowCount = 1;
                    }

                    var currPoint = sortedPoints.ElementAt(rowColCount - rowCount);
                    sortedRows.Add(currPoint);
                    sortedPoints.Remove(currPoint);

                    rowCount++;
                }
            }

            return sortedRows;
        }

        public static IEnumerable<Point> SortColumns(this IEnumerable<Point> points, int numPerColumn)
        {
            var sortedColumns = new List<Point>();
            var totalPointsCount = points.Count();
            var initColIdx = 0;
            var colIdx = 0;

            while (sortedColumns.Count < totalPointsCount)
            {
                sortedColumns.Add(points.ElementAt(colIdx));
                colIdx += numPerColumn;

                if(colIdx >= totalPointsCount)
                {
                    initColIdx++;
                    colIdx = initColIdx;
                }
            }

            return sortedColumns;
        }
    }
}
