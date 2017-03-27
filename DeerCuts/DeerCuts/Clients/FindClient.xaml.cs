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
            try
            {
                String address = txtAddress.Text;
                String email = txtEmail.Text;
                String first = txtFirstName.Text;
                String last = txtLastName.Text;
                String license = txtLicenseNumber.Text;
                String phone = txtPhone.Text;
                Boolean hasMatch = false;
                DbMgr db = new DbMgr();
                List<Customer> customers = db.getCustomers();
                foreach (Customer c in customers)
                {
                    if(c.getAddress() == address)
                    {
                        setClientForm(c);
                        hasMatch = true;
                    }
                    if (c.getFirstName() == first)
                    {
                        setClientForm(c);
                        hasMatch = true;
                    }
                    if (c.getLastName() == last)
                    {
                        setClientForm(c);
                        hasMatch = true;
                    }
                    if (c.getEmail() == email)
                    {
                        setClientForm(c);
                        hasMatch = true;
                    }
                    if (c.getLicenseNumber() == license)
                    {
                        setClientForm(c);
                        hasMatch = true;
                    }
                    if (c.getPhoneNumber() == phone)
                    {
                        hasMatch = true;
                        setClientForm(c);
                    }
                }
                if (!hasMatch)
                {
                    MessageBox.Show("match not found", "No Data Found");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Exception Occurred");
            }

        }

        private void setClientForm(Customer c)
        {
            txtAddress.Text = c.getAddress();
            txtEmail.Text = c.getEmail();
            txtFirstName.Text = c.getFirstName();
            txtLastName.Text = c.getLastName();
            txtLicenseNumber.Text = c.getLicenseNumber();
            txtPhone.Text = c.getPhoneNumber();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtLicenseNumber.Text = "";
            txtPhone.Text = "";
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
                MessageBox.Show(exc.ToString(), "Exception Occurred");
            }
        }
    }
}
