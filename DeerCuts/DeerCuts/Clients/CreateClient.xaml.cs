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
    /// Interaction logic for CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        public CreateClient()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtPIN.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                customer.setAddress(txtAddress.Text);
                customer.setEmail(txtEmail.Text);
                customer.setFirstName(txtFirstName.Text);
                customer.setLastName(txtLastName.Text);
                customer.setLicenseNumber(txtLicenseNumber.Text);
                customer.setPhoneNumber(txtPhone.Text);
                customer.setPassword(txtPIN.Text);
                customer.setLogin(txtEmail.Text);
                customer.setId(123123);
                DbMgr db = new DbMgr();
                Boolean succ = db.save(customer);
                if (succ)
                {
                    ManageClients clients = new ManageClients();
                    clients.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed", "failue");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception Occurred", exc.ToString());
            }
           
        }

        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dashboard dash = new Dashboard();
                dash.Show();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception Occurred", exc.ToString());
            }

        }
    }
}
