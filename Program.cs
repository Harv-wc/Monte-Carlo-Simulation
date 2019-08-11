using System;

namespace Monte_Carlo_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            do      // Clean this up later with separate classes and methods...
            {
                Console.Clear();
                GenerateBounds Bounds = new GenerateBounds { };
                double green = 0; // # of times in bound
                double red = 0;   // # of times not in bound
                int iterations = 100000; // # of iterations used to test bounds to determine the domain
                var result = Bounds.Domain(iterations, green, red);
                green = result.Item1;
                red = result.Item2;
                double perc = green / Convert.ToDouble(iterations) * 100;
                double PiApproximation = green / red;
                double error = Math.Abs(PiApproximation - Math.PI);
                double errorPerc = (error / Math.PI) * 100;         // Im way off for some reason. solid 15-18% error most of the time.
                Console.WriteLine($"iterations: {iterations}\n" +
                    $"green = {green}\n" +
                    $"red = {red}\n" +
                    $"green covers approx. {perc}% of the area\n" +
                    $"the approximate value of Pi is {PiApproximation}.\n" +
                    $"The error of difference of generated Pi: {error}\n" +
                    $"Randomly generated Pi is off by {Convert.ToInt32(errorPerc)}%");
                Console.WriteLine("Press Enter to escape");
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
    }

    class GenerateBounds
    {
        public Tuple<double, double> Domain(int iterations, double green, double red)
        {
            Random xAxis = new Random();
            Random yAxis = new Random();
            for (int i = 0; i < iterations; i++)
            {
                double xValue = xAxis.NextDouble();
                double yValue = yAxis.NextDouble();
                _ = Math.Sqrt(Math.Pow(xValue, 2.0) + Math.Pow(yValue, 2.0)) < 1.0 ? green++ : red++;
            }
            return Tuple.Create(green, red);
        }
    }
}
