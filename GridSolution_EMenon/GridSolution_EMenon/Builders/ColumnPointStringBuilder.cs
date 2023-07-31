using GridSolution_EMenon.Models;
using System.Collections.Generic;
using System.Text;

namespace GridSolution_EMenon.Builders
{
    public class ColumnPointStringBuilder : PointStringBuilder
    {
        public ColumnPointStringBuilder(IEnumerable<Point> sortedPoints) : base(sortedPoints)
        {
        }

        public override string BuildPointStringOutput(int rowColCount)
        {
            var currColIdx = rowColCount;
            var colNum = 0;
            var outputBuilder = new StringBuilder();

            foreach (var sortedColumn in SortedPoints)
            {
                if (currColIdx == 0)
                {
                    currColIdx = rowColCount;
                }

                if (currColIdx == rowColCount)
                {
                    outputBuilder.Append($"\nColumn {colNum}: ");
                    colNum++;
                }

                else
                {
                    outputBuilder.Append(" - ");
                }

                outputBuilder.Append(sortedColumn);
                currColIdx--;
            }

            return outputBuilder.ToString();
        }
    }
}
