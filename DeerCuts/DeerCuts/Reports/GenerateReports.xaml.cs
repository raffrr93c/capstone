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
using System.Windows.Shapes;

namespace DeerCuts
{
    /// <summary>
    /// Interaction logic for GenerateReports.xaml
    /// </summary>
    public partial class GenerateReports : Window
    {
        public GenerateReports()
        {
            InitializeComponent();
        }

        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
