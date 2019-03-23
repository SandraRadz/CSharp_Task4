using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;

namespace СSharp_Task4.Tools
{
    class PersonRepository
    {
        private static readonly List<Person> Persons = new List<Person>();


        internal void Add(Person person)
        {
            Persons.Add(person);
        }
        internal void Remove(Person patient)
        {
            Persons.Remove(patient);
        }

    }
}
