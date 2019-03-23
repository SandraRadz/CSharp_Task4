using System.Windows;
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
