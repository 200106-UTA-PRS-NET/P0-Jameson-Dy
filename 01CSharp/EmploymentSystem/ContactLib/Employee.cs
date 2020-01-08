using System;
using System.Collections.Generic;
using System.Text;

namespace ContactLib
{
    public class Employee
    {
        public int Id { get; set; }
        public Contact contact { get; set; }
        // numbers datatypes:
        // bytes - 1, int - 4 , long - 8 bytes
        // float - 4, double - 8, decimal(monetary) - 8/16 bytes
        protected decimal salary;
        protected float bsal;
        protected float hra;
        protected float tax;
        protected float medical;
        protected float bonus;

        public decimal GetSalary()
        {
            tax = 0.3f * bsal;
            return salary = (decimal) (bsal + hra + bonus - tax - medical);
        }
        public decimal GetSalary(float bsal)
        {
            tax = 0.3f * bsal;
            return salary = (decimal)(bsal + hra + bonus - tax - medical);
        }
        public decimal GetSalary(double bsal, float bonus)
        {
            tax = (float) CalculateTax((float) bsal);
            return salary = (decimal) (bsal + hra + bonus - tax - medical);
        }

        protected virtual decimal CalculateTax(float bsal)
        {
            return (decimal) (tax = 0.3f * bsal);
        }

        public Employee()
        {
            bsal = 5000.00f;
            hra = 2000.00f;
            medical = 200.00f;
            bonus = 2000.00f;
            Id = 420;
        }

        public Employee(float bsal, float hra, float tax, float bonus, float medical, int id)
        {
            this.bsal = bsal;
            this.hra = hra;
            this.tax = tax;
            this.bonus = bonus;
            this.medical = medical;
            this.Id = id;
        }
    }
}
