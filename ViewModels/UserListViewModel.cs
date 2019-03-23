using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using СSharp_Task4.Annotations;
using СSharp_Task4.Tools;

namespace СSharp_Task4.ViewModels
{
    class UserListViewModel : INotifyPropertyChanged
    {

        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string AppFolderPath =
            Path.Combine(AppDataPath, "CSharp_HW4");

        internal static readonly string StorageFilePath =
            Path.Combine(AppFolderPath, "PersonList.cskma");

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        internal UserListViewModel()
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
                    string[] lastNames = {"Rubka", "Kraevoy", "Volkov", "Sobolevsky", "Kreyman"};
                    string[] firstNames = { "Mary", "Ann", "Katy", "Danya", "Hlib", "Vova"};
                    string fn;
                    string ln;
                    for (int i = 0; i < 50; i++)
                        Persons.Add(new Person(fn=firstNames[rnd.Next(0, 6)], ln=lastNames[rnd.Next(0, 5)], $"{fn}{ln}@ukma.edu.ua", new DateTime(rnd.Next(DateTime.Today.Year - 100, DateTime.Today.Year - 1), rnd.Next(1, 13), rnd.Next(1, 30))));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
