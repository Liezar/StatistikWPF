using System.Collections.Generic;
using System.Windows;

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
            if (lstNames.Items.IsEmpty)
            {
                foreach (KeyValuePair<string, object> kvp in Statistics.DescriptiveStatistics()) // Skriver ut resultatet från Dictionary.
                {
                    lstNames.Items.Add($"{kvp.Key}: {kvp.Value}");
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstNames.Items.Clear();
        }
    }
}
