using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public enum TypeCompany
    {
        IE = 1, LLC = 2, CJSC = 3, UE = 4
    }
    class Company // по условию Банк может являться Предприятием (так что мб наследовать Банк от Предприятия?) upd: Спорно т.к. предприятие имеет банк (косвенно)
    {
        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value != TypeCompany.CJSC.ToString() || value != TypeCompany.LLC.ToString() || value != TypeCompany.IE.ToString() || value != TypeCompany.UE.ToString())
                {
                    throw new ArgumentException();
                }
                else
                {
                    _type = value;
                }
            }
        }
        public string LegalName { get; private set; }
        public readonly string SAN; //readonly только в конструкторе и при объявлении (но не в методах) 
        public string BIC { get; private set; }
        public string LegalAdress { get; private set; }
    }
}
