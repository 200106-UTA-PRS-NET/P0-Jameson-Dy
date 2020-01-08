using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    //class Mathematics : Arithmetic
    class Mathematics:IArithmetic, IMoreArithmetic
    {
        double IArithmetic.Subs(double a, double b)
        {
            return a - b;
        }

        public double Divide(double numerator, double denominator)
        {
            return numerator / denominator;
        }

        public double Add(params double[] num)
        {
            double result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                result += num[i];
            }
            return result;
        }

        double IMoreArithmetic.Add(int a, int b)
        {
            return a + b;
        }

        public double Subs(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
