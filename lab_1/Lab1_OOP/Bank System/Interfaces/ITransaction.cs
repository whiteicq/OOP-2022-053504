using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public interface ITransaction
    {
        void PutMoney(double sum);
        double TakeMoney(double sum);
        double MoneyBalance { get; }
    }
}
