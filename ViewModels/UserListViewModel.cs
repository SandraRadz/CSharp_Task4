using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools;
using СSharp_Task4.Annotations;
using СSharp_Task4.Tools;

namespace СSharp_Task4.ViewModels
{
    class UserListViewModel : INotifyPropertyChanged
    {

        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _birth;

        private ObservableCollection<Person> _persons;

        private RelayCommand<object> _addUserCommand;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Birth
        {
            get
            {
                return ("birth " + _birth);
            }
            set
            {
                _birth = Convert.ToDateTime(value);
                OnPropertyChanged();
            }
        }

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
            _persons = new ObservableCollection<Person>(PersonListHelper.Persons);
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addUserCommand ?? (_addUserCommand = new RelayCommand<object>(CreateUser));
            }
        }

        private async void CreateUser(object o)
        {

            var done = await Task.Run(() =>
            {
                try
                {
                    StationManager.CurrentUser = new Person(_name, _lastName, _email, _birth);

                }
                catch (EmailError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (FutureDayError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (PastDayError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (NameError e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                MessageBox.Show("Successful input");
                return true;

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
