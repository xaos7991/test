using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{

    class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TypeOfPeople Sex { get; set; }
        public int Balance { get; set; }
        public List<string> Peoples { get; set; }
        public People()
        {
            Peoples = new List<string>();
        }
    }
    enum TypeOfPeople
    {
        Male,
        Female
    }

}
