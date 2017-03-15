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

namespace DeerCuts.Clients
{
    /// <summary>
    /// Interaction logic for FindClient.xaml
    /// </summary>
    public partial class FindClient : Window
    {
        public FindClient()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtLicenseNumber.Text = "";
            txtPhone.Text = "";
            txtPIN.Text = "";

        }

        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
