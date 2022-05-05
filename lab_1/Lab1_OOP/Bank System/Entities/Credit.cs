using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Credit: ICommercialLoan // аннуитетный график займа
    {
        public uint Percent { get; set; }
        public Terms Term { get; set; }
        public double Sum { get; private set; }
        public static Credit CreateCredit(double sum, uint percent, int month)
        {
            return new Credit(sum, percent, month);
        }
        private Credit(double sum, uint percent, int month)
        {
            Sum = sum;
            Percent = percent;
            Term = (Terms)month;
        }
        public double MonthlyPayment()
        { 
            double interestRate = Percent / 100 / Percent;
            return Sum * (interestRate + interestRate / (Math.Pow(1 + interestRate, (int)Term) - 1));
        }
        public double FinalPayment()
        {
            return MonthlyPayment() * (int)Term;
        }

    }
}
