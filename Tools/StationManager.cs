using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;

namespace СSharp_Task4.Tools
{
    class StationManager
    {
        internal static Person CurrentUser { get; set; }
        public static ObservableCollection<Person> UsersList { get; }
    }
}
