using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    interface IArithmetic
    {
        double Add(params double[] num);
        double Divide(double numerator, double denominator);
        double Subs(double a, double b);
    }

    interface IMoreArithmetic
    {
        double Add(int a, int b);
        double Subs(int a, int b);

    }
}
