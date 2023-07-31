using GridSolution_EMenon.Models;
using System.Collections.Generic;

namespace GridSolution_EMenon.Builders
{
    public abstract class PointStringBuilder
    {
        protected List<Point> SortedPoints { get; }

        public PointStringBuilder(IEnumerable<Point> sortedPoints)
        {
            SortedPoints = new List<Point>(sortedPoints);
        }

        public abstract string BuildPointStringOutput(int rowColCount);
    }
}
