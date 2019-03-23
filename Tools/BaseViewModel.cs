﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.ProgrammingInCSharp2019.Practice7.UserList.Properties;

namespace СSharp_Task4.Tools
{
    internal abstract class BaseViewModel:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
