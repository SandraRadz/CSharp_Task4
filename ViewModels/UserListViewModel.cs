using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice7.UserList.Properties;
using KMA.ProgrammingInCSharp2019.Practice7.UserList.Tools.Managers;
using СSharp_Task4.Tools;
using СSharp_Task4.Tools.Managers;

namespace СSharp_Task4.ViewModels
{
    class UserListViewModel : INotifyPropertyChanged
    {

        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _birth;
        public Person SelectedItem { get; set; }

        private ObservableCollection<Person> _persons;

        private RelayCommand<object> _addUserCommand;
        private RelayCommand<object> _editUserCommand;
        private RelayCommand<object> _saveUserCommand;
        private RelayCommand<object> _deleteUserCommand;


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
        public DateTime Birth
        {
            get
            {
                return  _birth;
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
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addUserCommand ?? (_addUserCommand = new RelayCommand<object>(
                           CreateUser, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _editUserCommand ?? (_editUserCommand = new RelayCommand<object>(
                           EditUser));
            }
        }

    
        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _deleteUserCommand ?? (_deleteUserCommand = new RelayCommand<object>(
                           DeleteUser));
            }
        }

        private async void CreateUser(object o)
        {
            LoaderManager.Instance.ShowLoader();
            var done = await Task.Run(() =>
            {
                try
                {
                    StationManager.DataStorage.AddUser(new Person(_name, _lastName, _email, _birth));
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
                    MessageBox.Show("Yes");

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

                
                return true;

            });
           if (done)
                {
                Name = "";
                LastName = "";
                Email = "";
                Birth = DateTime.Today;

             }
            LoaderManager.Instance.HideLoader();
        }

        private async void DeleteUser(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                try
                {
                   
                    StationManager.DataStorage.DeleteUser(SelectedItem);
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
                    MessageBox.Show("Yes");
                }
                catch(Exception e)
                {
                    MessageBox.Show("Some trouble with delete");
               }
            });
            LoaderManager.Instance.HideLoader();
        }

        private async void EditUser(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                try
                {
                    
                    Name = SelectedItem.Name;
                    LastName = SelectedItem.LastName;
                    Email = SelectedItem.Email;
                    Birth = SelectedItem.Birth;
                    DeleteUser(SelectedItem);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Some trouble with edit");
                }
            });
            LoaderManager.Instance.HideLoader();
        }

     

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_email) && !(_birth == default(DateTime));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
