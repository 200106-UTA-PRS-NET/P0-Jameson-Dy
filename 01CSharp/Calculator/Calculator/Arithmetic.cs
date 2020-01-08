using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public abstract class Arithmetic
    {
        public virtual double Add(params double[] numbers)
        {
            double result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }
        public abstract double Subs(double a, double b);
        public abstract double Divide(double numerator, double denominator);

    }
}
