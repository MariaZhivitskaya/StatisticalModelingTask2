using System;

namespace StatisticalModelingTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            double p = 0.75;
            int a = 0;
            int b = 10;
          
            string fileNameGeometric = "GeneratorGeometric.txt";
            string testFileNameGeometric = "TestsResultsGeometric.txt";
            string fileNameDiscreteEven = "GeneratorDiscreteEven.txt";
            string testFileNameDiscreteEven = "TestsResultsDiscreteEven.txt";
            Handler handler = new Handler();

            GeometricDistributionFunction geometricDistributionFunction =
               new GeometricDistributionFunction(p);
            DiscreteEvenDistributionFunction discreteEvenDistributionFunction =
                new DiscreteEvenDistributionFunction(a, b);

            int[] sequenceGeometric = handler.Generate(n, geometricDistributionFunction);
            Handler.WriteFile(sequenceGeometric, fileNameGeometric, p, n);

            int[] sequenceDiscreteEven = handler.Generate(n, discreteEvenDistributionFunction);
            Handler.WriteFile(sequenceDiscreteEven, fileNameDiscreteEven, a, b, n);

            Estimation est = new Estimation();
            double eps = 0.01;
            bool estimationResult;
           
            estimationResult = est.ChiSquaredCriteria(sequenceGeometric, geometricDistributionFunction,
                geometricDistributionFunction.GetValues(), eps);
            handler.WriteFileChiSquaredCriteria(est.ChiSquaredCriteriaP, estimationResult, testFileNameGeometric);

            estimationResult = est.ChiSquaredCriteria(sequenceDiscreteEven, discreteEvenDistributionFunction,
                discreteEvenDistributionFunction.GetValues(), eps);
            handler.WriteFileChiSquaredCriteria(est.ChiSquaredCriteriaP, estimationResult, testFileNameDiscreteEven);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
