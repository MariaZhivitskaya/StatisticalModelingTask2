using System;

namespace StatisticalModelingTask2
{
    public class BernoulliDistributionFunction
        
    {
        private readonly double p;

        public BernoulliDistributionFunction(double p)
        {
            this.p = p;
        }

        public double F(double x)
        {
            if (x <= 0)
            {
                return Left();
            }
            else if (x > 1)
            {
                return Right();
            }

            return Sum(x);
        }

        public double Left()
        {
            return 0;
        }

        public double Right()
        {
            return 1;
        }

        private double Sum(double x)
        {
            double sum = 0;

            for (int i = 0; i <= x; i++)
            {
                sum += Math.Pow(p, i)*Math.Pow(1 - p, 1 - i);
            }

            return sum;
        }
    }
}