using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    interface ICommercialLoan
    { 
        uint Percent { get; }
        double Sum { get; }
        double MonthlyPayment();
        double FinalPayment();
    }
}
