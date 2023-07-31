using GridSolution_EMenon.Models;
using System;

namespace GridSolution_EMenon.Utils
{
    public class AlphaCalculator
    {
        private Point HighestPoint { get; }
        private Point NextHighestPoint { get; }

        public AlphaCalculator(Point highestPoint, Point nextPoint)
        {
            HighestPoint = highestPoint;
            NextHighestPoint = nextPoint;
        }

        /* To find the angle, I calculate the sides of a smaller triangle
         * using the highest point of the grid (row 0, column n)
         * and the point to the left of it (row 0, column n-1)
         * in order to determine the height and width of a triangle
         * which would have the same angle as the angle between the x-axis
         * and the grid rows. I then use the arctan function to get the
         * angle in radians, then convert it into degrees.
         */
        public double CalculateAlpha()
        {
            var yDifference = HighestPoint.Y - NextHighestPoint.Y;
            var xDifference = HighestPoint.X - NextHighestPoint.X;

            var alphaRadian = Math.Atan2(yDifference, xDifference);
            var alphaDegrees = alphaRadian * (180 / Math.PI);

            //if angle is negative, convert to positive degrees
            if(alphaDegrees < 0)
            {
                alphaDegrees +=180;
            }

            return Math.Round(alphaDegrees, 1);
        }
    }
}
