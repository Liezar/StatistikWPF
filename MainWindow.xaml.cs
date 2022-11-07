using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int[] JsonData()
        {
            //Json filen måste ligga i användare och den måste heta data.json
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/data.json");
            string jsonString = File.ReadAllText(filePath);
            int[] import = JsonConvert.DeserializeObject<int[]>(jsonString);
            return import;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
