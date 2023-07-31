using GridSolution_EMenon.Models;
using System.Collections.Generic;
using System.Text;

namespace GridSolution_EMenon.Builders
{
    public class RowPointStringBuilder: PointStringBuilder
    {
        public RowPointStringBuilder(IEnumerable<Point> rowSortedPoints) : base(rowSortedPoints)
        {
        }

        public override string BuildPointStringOutput(int rowColCount)
        {
            var currRowIdx = rowColCount;
            var rowNum = 0;
            var outputBuilder = new StringBuilder();

            foreach (var sortedRow in SortedPoints)
            {
                if (currRowIdx == 0)
                {
                    currRowIdx = rowColCount;
                }

                if (currRowIdx == rowColCount)
                {
                    outputBuilder.Append($"\nRow {rowNum}: ");
                    rowNum++;
                }

                else
                {
                    outputBuilder.Append(" - ");
                }

                outputBuilder.Append(sortedRow);
                currRowIdx--;
            }

            return outputBuilder.ToString();
        }
    }
}
