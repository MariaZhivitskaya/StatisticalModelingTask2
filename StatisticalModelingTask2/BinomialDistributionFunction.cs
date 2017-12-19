using System;
using System.Collections.Generic;

namespace StatisticalModelingTask2
{
    public class BinomialDistributionFunction
        
    {
        private readonly double p;
        private readonly int n;

        private List<double> pi;
        private int nFact; 

        public BinomialDistributionFunction(double p, int n)
        {
            this.p = p;
            this.n = n;
            pi = new List<double>(n + 1);
         
            nFact = CountFact(n);

            for (int k = 0; k <= n; k++)
            {
                pi.Add(Cnk(k) * Math.Pow(p, k) * Math.Pow(1 - p, n - k));
            }
        }

        public double F(double x)
        {
            if (x <= 0)
            {
                return Left();
            }
            else if (x > n)
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

        private int CountFact(int index)
        {
            int res = 1;

            for (int i = 1; i <= index; i++)
            {
                res *= i;
            }

            return res;
        }

        private double Cnk(int k)
        {
            return nFact/(CountFact(k)*CountFact(n - k));
        }

        private double Sum(double x)
        {
            double sum = 0;

            for (int i = 0; i <= x; i++)
            {
                sum += pi[i];
            }

            return sum;
        }
    }
}