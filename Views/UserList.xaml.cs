using System;
using System.Collections.Generic;
using System.Windows.Controls;
using СSharp_Task4.ViewModels;

namespace СSharp_Task4
{
    public partial class UserList : UserControl
    {
        public UserList()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();
        }

        
    }
}
