using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalModelingTask2
{
    class Estimation
    {
        private readonly double[] argsChi =
       {
            1.73493, 2.08790, 2.70039, 3.32511, 4.16816, 5.89883,
            8.34283, 11.38875, 14.68366, 16.91898, 19.02277, 21.66599, 23.58935, 1000
        };

        private readonly double[] Chi =
        {
            0.995, 0.990, 0.975, 0.950, 0.900, 0.750,
            0.500, 0.250, 0.100, 0.050, 0.025, 0.010, 0.005, 0.0001
        };

        private int n;
        public double ChiSquaredCriteriaP { get; private set; }

        public bool ChiSquaredCriteria(int[] sequence, IDistributionFunction func, int[] values, double eps)
        {
            n = sequence.Length;
            int K = values.Length;

            int[] v = new int[K];
            foreach (double elem in sequence)
            {
                if (Math.Floor(elem) == elem)
                    v[(int)elem]++;
            }
            
            double[] p0 = new double[K + 1];

            for (int i = values[0]; i < values[values.Length - 1]; i++)
            {
                p0[i] = func.P(i);
            }


            double X2 = 0;
            for (int i = values[0]; i < values[values.Length - 1]; i++)
            {
                double j = Math.Pow(v[i] - p0[i] * n, 2) / (n * p0[i]);
                X2 += j;
            }

            ChiSquaredCriteriaP = GetChi(X2);

            return ChiSquaredCriteriaP >= eps;
        }

        private double GetChi(double X2)
        {
            for (int i = 0; i < argsChi.Length; i++)
            {
                if (X2 <= argsChi[i])
                {
                    return Chi[i];
                }
            }

            return 0;
        }
    }
}
