using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;

namespace СSharp_Task4.Tools
{
    class PersonListHelper
    {
        private static readonly string AppDataPath =
           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string AppFolderPath =
            Path.Combine(AppDataPath, "CSharp_HW4");

        internal static readonly string StorageFilePath =
            Path.Combine(AppFolderPath, "PersonList_Radzievska.cskma");

        private static ObservableCollection<Person> _persons;

        public static ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
            }
        }

        static PersonListHelper()
        {
            {
                if (File.Exists(StorageFilePath))
                {
                    try
                    {
                        Persons = SerializationManager.Deserialize<ObservableCollection<Person>>(StorageFilePath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to get users from file.{Environment.NewLine}{ex.Message}");
                        throw;
                    }
                }
                else
                {
                    Persons = new ObservableCollection<Person>();
                    Random rnd = new Random();
                    string[] lastNames = { "Rubka", "Kraevoy", "Volkov", "Sobolevsky", "Kreyman" };
                    string[] firstNames = { "Mary", "Ann", "Katy", "Danya", "Hlib", "Vova" };
                    string fn;
                    string ln;
                    for (int i = 0; i < 50; i++)
                        Persons.Add(new Person(fn = firstNames[rnd.Next(0, 6)], ln = lastNames[rnd.Next(0, 5)], $"{fn}{ln}@ukma.edu.ua", new DateTime(rnd.Next(DateTime.Today.Year - 100, DateTime.Today.Year - 1), rnd.Next(1, 13), rnd.Next(1, 30))));
                }
            }
        }

        internal static void SaveData()
        {
            SerializationManager.Serialize(Persons, StorageFilePath);
        }

        internal static Person AddPerson(string lastName, string firstName, string email, DateTime date)
        {
            Person person = new Person(firstName, lastName, email, date);
            Persons.Add(person);
            return person;
        }
    }
}
