using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnData_Click(object sender, RoutedEventArgs e)
        {
            foreach (KeyValuePair<string, object> kvp in Statistics.DescriptiveStatistics()) // Skriver ut resultatet från Dictionary.
            {
                lstNames.Items.Add($"{kvp.Key}: {kvp.Value}");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstNames.Items.Clear();
        }
    }
}
