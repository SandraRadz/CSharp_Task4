using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using СSharp_Task4.Annotations;
using СSharp_Task4.Tools;

namespace СSharp_Task4.ViewModels
{
    class UserListViewModel : INotifyPropertyChanged
    {
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
            _persons = new ObservableCollection<Person>
            {
                new Person("Olha", "Fin", "dfd@dd.ds"),
                new Person("Danya", "Kreyman", "dfdfd@dd.ds"),
                new Person("Sasha", "Fin", "dfd@dd.ds")

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
