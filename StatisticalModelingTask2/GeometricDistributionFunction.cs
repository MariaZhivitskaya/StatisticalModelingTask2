using System;

namespace StatisticalModelingTask2
{
    class GeometricDistributionFunction
        : IDistributionFunction
    {
        private double p;

        public GeometricDistributionFunction(double p)
        {
            this.p = p;
        }

        public double F(double x)
        {
            return 1 - Math.Pow(1 - p, x);
        }

        public double Left()
        {
            return 1;
        }

        public double Right()
        {
            return int.MaxValue;
        }

        public double GetValue(double x)
        {
            return Math.Ceiling(Math.Log(x)/Math.Log(1.0 - p));
        }

        public int[] GetValues()
        {
            int n = 10;
            int[] values = new int[n];

            for (int i = 0; i < n; i++)
            {
                values[i] = i + 1;
            }

            return values;
        }

        public double P(double x)
        {
            return p * Math.Pow(1 - p, Math.Floor(x) - 1);
        }
    }
}
