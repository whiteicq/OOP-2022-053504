using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{ // добавить серии через енам
    
    class PassportBY
    {
        public string SNP { get; }
        public string Number { get; set; }
        public PassportSeries Series { get; set; }
        public string IdentificationNumber { get; set; }
        public PassportBY(string number, int series, string identification)
        {
            Number = number;
            Series = (PassportSeries)series;
            IdentificationNumber = identification;
        }
        public override string ToString()
        {
            return $"{Series}{Number}: {IdentificationNumber}";
        }
    }
}
