using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Client: User
    { 
        public List<BankAccount> Accounts = new List<BankAccount>();
        private double _pocketMoney;
        public double PocketMoney
        {
            get
            {
                return _pocketMoney;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _pocketMoney = value;
                }
            }
        }
        public Client(PassportBY passport, string phone, string number, double pocketMoney): base(passport, phone, number)
        {
            PocketMoney = pocketMoney;
        }
        public void CreateAccount(string login, string password, double money = 0)
        {
            if (money < PocketMoney)
            {
                PocketMoney -= money;
                Accounts.Add(BankAccount.OpenAccount(money, login, password));
            }
            else
            {
                throw new Exception("insufficient funds");
            }
        }
        public void GetMoney(double sum, int numberAcc) // снять со счета на карман
        {
            if (Accounts[numberAcc].MoneyBalance != 0 && Accounts[numberAcc].MoneyBalance > sum)
            {
                PocketMoney += Accounts[numberAcc].TakeMoney(sum);
            }
            else { throw new Exception("fghj"); }
        }

        public void GiveMoney(double sum, int numberAcc) // положить с кармана на счет
        {
            if(PocketMoney > sum)
            {
                Accounts[numberAcc].PutMoney(sum);
                PocketMoney -= sum;
            }
        }
        public void GiveMoneyOtherAccount(double sum, int numberAcc, BankAccount otherAcc)
        {
            Accounts[numberAcc].PutOnAccount(sum, otherAcc);
        }

        // добавить методы для кредитов и подумать над рефакторингом (мб работу со счетом и с кредитами на счете вынести в отдельный класс как пример)
        // для апрува вероятно пригодится Наблюдатель
    }
}
