using System;

namespace Monte_Carlo_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateBounds Bounds = new GenerateBounds { };
            int green = 0; // # of times in bound
            int red = 0;   // # of times not in bound
            int iterations = 100000; // # of iterations used to test bounds to determine the domain
            var result = Bounds.Domain(iterations);
            green = result.Item1;
            red = result.Item2;
            double perc = (Convert.ToDouble(green) / Convert.ToDouble(iterations)*100);
            Console.WriteLine($"iterations: {iterations}\ngreen = {green}\nred = {red}\ngreen covers approx. {perc}% of the area.");
        }

    }

    class GenerateBounds
    {
        public Tuple<int, int> Domain(int iterations)
        {
            int green = 0;
            int red = 0;
            Random xAxis = new Random();
            Random yAxis = new Random();

            for (int i = 0; i < iterations; i++)
            {
                double xValue = Math.Abs(xAxis.NextDouble());
                double yValue = Math.Abs(yAxis.NextDouble());
                _ = Math.Sqrt(Math.Pow(xValue, 2.0) + Math.Pow(yValue, 2.0)) <= 1.0 ? green++ : red++;
                double c = Math.Sqrt(Math.Pow(xValue, 2.0) + Math.Pow(yValue, 2.0));
            }
            return Tuple.Create(green, red);
        }
    }
}
