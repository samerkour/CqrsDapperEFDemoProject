using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTimePolicies
{
    public static class OverTimePolicies
    {
     
        public static long CalculatorA(this long baseSalary, long allowance)
        {
            return baseSalary + allowance;
        }

        public static long CalculatorB(this long baseSalary, long allowance)
        {
            return baseSalary + allowance;
        }

        public static long CalculatorC(this long baseSalary, long allowance)
        {
            return baseSalary + allowance;
        }
    }
}
