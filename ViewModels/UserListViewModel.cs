using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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

        private string _fName;
        private string _fLastName;
        private string _fEmail;
        private DateTime _fBirth;
        private string _fIsAdult;
        private string _fSunSign;
        private string _fChineseSign;
        private string _fIsBirth;

        public Person SelectedItem { get; set; }

        private ObservableCollection<Person> _persons;

        private RelayCommand<object> _addUserCommand;
        private RelayCommand<object> _editUserCommand;
        private RelayCommand<object> _deleteUserCommand;
        private RelayCommand<object> _allCommand;
        private RelayCommand<object> _filterCommand;

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

        public string FName
        {
            get
            {
                return _fName;
            }
            set
            {
                _fName = value;
                OnPropertyChanged();
            }
        }

        public string FLastName
        {
            get
            {
                return _fLastName;
            }
            set
            {
                _fLastName = value;
                OnPropertyChanged();
            }
        }
        public string FEmail
        {
            get
            {
                return _fEmail;
            }
            set
            {
                _fEmail = value;
                OnPropertyChanged();
            }
        }
        public DateTime FBirth
        {
            get
            {
                return _fBirth;
            }
            set
            {
                _fBirth = Convert.ToDateTime(value);
                OnPropertyChanged();
            }
        }

        public string FIsAdult
        {
            get
            {
                return ""+_fIsAdult;
            }
            set
            {
                _fIsAdult = value;
                OnPropertyChanged();
            }
        }

        public string FSunSign
        {
            get
            {
                return _fSunSign;
            }
            set
            {
                _fSunSign = value;
                OnPropertyChanged();
            }
        }
        public string FChineseSign
        {
            get
            {
                return _fChineseSign;
            }
            set
            {
                _fChineseSign = value;
                OnPropertyChanged();
            }
        }
        public string FIsBirth
        {
            get
            {
                return ""+_fIsBirth;
            }
            set
            {
                _fIsBirth = value;
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
            FName = "";
            FLastName = "";
            FEmail = "";
            FBirth = DateTime.MinValue;
            FIsAdult = "";
            FChineseSign = "";
            FSunSign = "";
            FIsBirth = "";
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

        public RelayCommand<object> AllCommand
        {
            get
            {
                return _allCommand ?? (_allCommand = new RelayCommand<object>(
                           GetAllUser));
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ?? (_filterCommand = new RelayCommand<object>(
                           GetFilteredUser));
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

        private async void GetAllUser(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                try
                {
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
                    FName = "";
                    FLastName = "";
                    FEmail = "";
                    FBirth = DateTime.MinValue;
                    FIsAdult = "";
                    FChineseSign = "";
                    FSunSign = "";
                    FIsBirth = "";

                }
                catch (Exception e)
                {
                    MessageBox.Show("Some trouble with filter");
                }
            });
            LoaderManager.Instance.HideLoader();
        }

        private async void GetFilteredUser(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                try
                {

                   var users = StationManager.DataStorage.UsersList;
                    var selectedUsers = from user in users
                        where (FName == "" || user.Name == FName)
                        where (FLastName == "" || user.LastName == FLastName)
                        where (FEmail == "" || user.Email == FEmail)
                        where (FBirth == DateTime.MinValue || user.Birth == FBirth)
                        where (FIsAdult == "" || user.IsAdult == Convert.ToBoolean(FIsAdult))
                        where (FChineseSign == "" || user.ChineseSign == FChineseSign)
                        where (FSunSign == "" || user.SunSign == FSunSign)
                        where (FIsBirth == "" || user.IsBirthday == Convert.ToBoolean(FIsBirth))

                                        select user;
                    Persons = new ObservableCollection<Person>(selectedUsers);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Some trouble with filter");
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
