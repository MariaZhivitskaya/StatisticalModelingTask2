namespace StatisticalModelingTask2
{
    public interface IDistributionFunction
    {
        double F(double x);
        double Left();
        double Right();
        double GetValue(double x);
        int[] GetValues();
        double P(double x);
    }
}