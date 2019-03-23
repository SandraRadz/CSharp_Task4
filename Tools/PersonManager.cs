using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;

namespace СSharp_Task4.Tools
{
    class PersonManager
    {
        readonly PersonRepository _personRepository;
        public PersonManager()
        {
            _personRepository = new PersonRepository();
        }

        public bool Add(Person person)
        {
            return true;
        }
}
}
