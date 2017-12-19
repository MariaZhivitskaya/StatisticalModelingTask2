using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalModelingTask2
{
    class DiscreteEvenDistributionFunction
        : IDistributionFunction
    {
        private int a;
        private int b;

        public DiscreteEvenDistributionFunction(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public double F(double x)
        {
            if (x < a)
            {
                return Left();
            }
            else if (x > b)
            {
                return Right();
            }
            return (x - a + 1)/(b - a + 1);
        }

        public double Left()
        {
            return 0;
        }

        public double Right()
        {
            return 1;
        }

        public double GetValue(double x)
        {
            return Math.Floor(x * (b - a + 1) + a);
        }

        public int[] GetValues()
        {
            int[] values = new int[b - a + 1];

            for (int i = 0; i < b - a + 1; i++)
            {
                values[i] = a + i;
            }

            return values;
        }

        public double P(double x)
        {
            return 1.0 / (b - a + 1);
        }
    }
}
