using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class BankAccount: ITransaction // наверняка можно заколхозить Состояние (блок/заморозка/нет денег на счету)
    {
        private bool _isExist = false; // для заморозки итп
        private string _password;
        private string _login;
        private double _moneyBalance;
        public string Password 
        {
            get
            {
                return _password;
            }
            private set
            {
                if (value.Length < 5 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _password = value;
                }
            }
        }
        public string Login
        {
            get
            {
                return _login; 
            } 
            private set
            {
                if(value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _login = value;
                }
            }
        }
        public double MoneyBalance 
        {
            get
            {
                return _moneyBalance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _moneyBalance = value;
                }
            }
        }
        public List<ICommercialLoan> Loans = new List<ICommercialLoan>();
        public void PutMoney(double sum) // зачислить на счет
        {
            MoneyBalance += sum;
        }
        public double TakeMoney(double sum) // снять со счета
        {
            if (sum < 0 || sum > MoneyBalance)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                MoneyBalance -= sum;
                return sum;
            }
        } // стоит реализовать хранение транзакций (через события или типо того как в прошлом семе)
          // перевод на другой счет
        public void PutOnAccount(double sum, BankAccount otherAccount) // перевод на другой счет
        {
            if (this.MoneyBalance == 0 || this.MoneyBalance < sum)
                {
                    throw new Exception("Not enough money");
                }
            this.MoneyBalance -= sum;
            otherAccount.MoneyBalance += sum;
        }
        public static BankAccount OpenAccount(double money, string login, string password)
        { 
            return new BankAccount(money, login, password);
        }
        // недодел
        public void CloseAccount()
        {
            _isExist = false; //недодел
        }
        public void CreateLoan(ICommercialLoan loan)
        {
            Loans.Add(loan);
        }
        public void RepayLoan(ICommercialLoan loan)
        {
            if (MoneyBalance > loan.Sum)
            {
                MoneyBalance -= Loans[Loans.IndexOf(loan)].FinalPayment();
                Loans.Remove(loan);
            }
            else
            {
                throw new Exception("Balance of account lesser than sum of loan");
            }
        }
        private BankAccount(double money, string login, string password)
        {
            Login = login;
            Password = password;
            _isExist = true;
            MoneyBalance = money;
        } 
        // мб сделать отдельный метод приватный чтобы заранее определить хватит ли денег на балансе для транзакций
    }
}
