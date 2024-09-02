using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SP_Task_1
{
    /// <summary>
    /// Interaction logic for ShowBlackList.xaml
    /// </summary>
    public partial class ShowBlackList : Window
    {
        private ObservableCollection<Process> processList;

        public ObservableCollection<Process> ProcessList { get => processList; set { processList = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ShowBlackList(List<string>BlackList)
        {
            ProcessList = new();
            DataGrid ProcessesDataGrid = new DataGrid();
            ProcessesDataGrid.AutoGenerateColumns = false;
            ProcessesDataGrid.CanUserAddRows = false;
            ProcessesDataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;
            ProcessesDataGrid.ItemsSource = new List<string>();
            ProcessesDataGrid.ItemsSource = BlackList;

            MainGrid.Children.Add(ProcessesDataGrid);
            InitializeComponent();
            DataContext = this;
        }
    }
}
