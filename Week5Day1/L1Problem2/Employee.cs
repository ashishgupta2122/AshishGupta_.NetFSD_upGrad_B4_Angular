using System;

namespace L1Problem2
{
    public class Employee
    {
        public string Name
        {
            get;
            set;
        }

        public double BaseSalary
        {
            get;
            set;
        }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }
}