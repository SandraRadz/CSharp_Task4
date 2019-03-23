using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using СSharp_Task4.Tools.Managers;

namespace СSharp_Task4.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _users;

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
                
                Random rnd = new Random();
                string[] lastNames = { "Rubka", "Kraevoy", "Volkov", "Sobolevsky", "Kreyman", "Maliukova", "Bondar", "Black", "Bond", "Bing" };
                string[] firstNames = { "Mary", "Ann", "Katy", "Danya", "Hlib", "Vova", "Alla", "Denys", "Sasha", "Maryna" };
                string fn;
                string ln;
                for (int i = 0; i < 50; i++)
                {
                    AddUser(new Person(fn = firstNames[rnd.Next(0, 10)], ln = lastNames[rnd.Next(0, 10)],
                        $"{fn}{ln}@ukma.edu.ua", new DateTime(
                            rnd.Next(DateTime.Today.Year - 100, DateTime.Today.Year - 1),
                            rnd.Next(1, 13), rnd.Next(1, 30))));
                }
               
                SaveChanges();
            }
        }
       /* 
        public bool UserExists(string login)
        {
            return _users.Exists(u => u.Login == login);
        }

        public User GetUserByLogin(string login)
        {
            return _users.FirstOrDefault(u => u.Login == login);
        }
        */
        public List<Person> AddUser(Person user)
        {
            _users.Add(user);
            SaveChanges();
            return _users;
        }

        public List<Person> DeleteUser(Person user)
        {
            _users.Remove(user);
            SaveChanges();
            return _users;
        }

        public List<Person> UsersList
        {
            get { return _users.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }
        
    }
}

