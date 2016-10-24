using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch9.R2.Calc
{
    public class CalculatorCore
    {
        public double Add(params float[] numbers)
        {
            double value = 0;
            foreach (var item in numbers)
            {
                if (item < 0)
                {
                    throw new InvalidOperationException("Use positive numbers only");
                }
                else
                {
                    value += item;
                }
            }
            return 0;
        }
    }
}
