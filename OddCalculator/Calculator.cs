namespace OddCalculator
{
    class Calculator
    {
        public double Factorial(double i)
        {
            i = (int)i;
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
