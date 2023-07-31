namespace GridSolution_EMenon.Models
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0:0.0},{1:0.0}", X, Y);
        }
    }
}
