using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    abstract class User
    {
        public PassportBY Passport { get; } // contain contact info by user
        public string Phone { get; }
        public string Email { get; }
        public User(PassportBY passport, string number, string mail)
        {
            Passport = passport;
            Phone = number;
            Email = mail;
        }
        public User(PassportBY passport) { }
    }
}
