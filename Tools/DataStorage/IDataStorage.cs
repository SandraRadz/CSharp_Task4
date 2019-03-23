using System.Collections.Generic;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;

namespace СSharp_Task4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        //bool UserExists(string login);

        //Person GetUserByLogin(string login);

        void AddUser(Person user);
        List<Person> UsersList { get; }
    }
}
