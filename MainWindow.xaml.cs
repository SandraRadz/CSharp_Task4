using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using СSharp_Task4.Tools;
using СSharp_Task4.Tools.DataStorage;
using СSharp_Task4.Tools.Managers;
using СSharp_Task4.ViewModels;

namespace СSharp_Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeApplication();
            InitializeComponent();
            DataContext = new MainWindowViewModel();
   
        }

        private void InitializeApplication()
        {
            StationManager.Initialize(new SerializedDataStorage());
         }
        
    }
}
