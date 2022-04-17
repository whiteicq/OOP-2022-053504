using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age} Height: {Height}";
        }
    }
}
