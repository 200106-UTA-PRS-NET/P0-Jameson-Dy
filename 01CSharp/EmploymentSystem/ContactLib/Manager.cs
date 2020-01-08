using System;
using System.Collections.Generic;
using System.Text;

namespace ContactLib
{
    public class Manager : Employee
    {
        public Manager(float bsal, float hra, float tax, float bonus, float medical, int id)
            :base(bsal, hra, tax, bonus, medical, id)
        {

        }

        protected override decimal CalculateTax(float bsal)
        {
            return (decimal)(tax = 0.3f * bsal);
        }
    }
}
