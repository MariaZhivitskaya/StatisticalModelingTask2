using System;
using System.ComponentModel;
using System.IO;

namespace StatisticalModelingTask2
{
    class Handler
    {
        private readonly Random random = new Random();
        private readonly object syncLock = new object();

        public int[] Generate(int n, IDistributionFunction distributionFunction)
        {
            int[] sequence = new int[n];
            double randDouble;

            for (int i = 0; i < n; i++)
            {
                randDouble = RandomDouble();
                sequence[i] = (int)distributionFunction.GetValue(randDouble);
            }

            return sequence;
        }

        private double RandomDouble()
        {
            lock (syncLock)
            {
                return random.NextDouble();
            }
        }

        public static void WriteFile(int[] sequence, string fileName, double p, int n)
        {
            using (var file = new StreamWriter(fileName))
            {
                file.WriteLine("p = {0}, n = {1}\n", p, n);
                foreach (var element in sequence)
                {
                    file.Write("{0} ", element);
                }
                file.WriteLine("\n");
            }
        }

        public static void WriteFile(int[] sequence, string fileName, int a, int b, int n)
        {
            using (var file = new StreamWriter(fileName))
            {
                file.WriteLine("a = {0}, b = {1}, n = {2}\n", a, b, n);
                foreach (var element in sequence)
                {
                    file.Write("{0} ", element);
                }
                file.WriteLine("\n");
            }
        }

        public void WriteFileChiSquaredCriteria(double p, bool isCorrect, string fileName)
        {
            using (var file = new StreamWriter(fileName))
            {
                file.WriteLine("Chi Squared Criteria");
                file.WriteLine("p = {0}\n", p);
                file.WriteLine(WriteResult(isCorrect));
                file.WriteLine("-----------------------------------------");
            }
        }

        private string WriteResult(bool isCorrect)
        {
            return "Random selection is " + (isCorrect ? "correct" : "not correct");
        }
    }
}
