using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace SP_Task_1
{
   
    public partial class RunNewTask : Window
    {
        List<string> blackList = new();
        public RunNewTask(List<string> BlakList)
        {
            InitializeComponent();
            this.blackList = BlakList;
        }
        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OKButtonClick(object sender, RoutedEventArgs e)
        {

            bool isCheck = false;
            foreach (var item in blackList)
            {
                int id = -1;
                if (item == TxtBox.Text)
                {
                    isCheck = true;
                    Process.Start(TxtBox.Text);
                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName == TxtBox.Text)
                            id = process.Id;
                    }
                    Thread.Sleep(1000);
                    Process.GetProcessById(id).Kill();
                }
            }
            if (!isCheck)
                Process.Start(TxtBox.Text);
        }

        private void BrowseButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            TxtBox.Text = openFileDialog.FileName;
        }
    }
}
