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
    /// Interaction logic for UpdateClient.xaml
    /// </summary>
    public partial class UpdateClient : Window
    {
        public UpdateClient()
        {
            InitializeComponent();
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

        private void setClientForm(Customer c)
        {
            txtAddress.Text = c.getAddress();
            txtEmail.Text = c.getEmail();
            txtFirstName.Text = c.getFirstName();
            txtLastName.Text = c.getLastName();
            txtLicenseNumber.Text = c.getLicenseNumber();
            txtPhone.Text = c.getPhoneNumber();
            txtPIN.Text = c.getPassword();
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
                    MessageBox.Show("Failure to save Customer data, please try again", "Failed");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Exception Occurred");
            }
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
                DbMgr db = new DbMgr();
                List<Customer> customers = db.getCustomers();
                foreach (Customer c in customers)
                {
                    if (c.getAddress() == address)
                    {
                        MessageBox.Show("match found" + c.ToString(), "Data found");
                        setClientForm(c);
                    }
                    if (c.getFirstName() == first)
                    {
                        MessageBox.Show("match found" + c.ToString(), "Data found");
                        setClientForm(c);
                    }
                    if (c.getLastName() == last)
                    {
                        MessageBox.Show("match found" + c.ToString(), "Data found");
                        setClientForm(c);
                    }
                    if (c.getEmail() == email)
                    {
                        MessageBox.Show("match found" + c.ToString(), "Data found");
                        setClientForm(c);
                    }
                    if (c.getLicenseNumber() == license)
                    {
                        MessageBox.Show("match found" + c.ToString(), "Data found");
                        setClientForm(c);
                    }
                    if (c.getPhoneNumber() == phone)
                    {
                        MessageBox.Show("match found" + c.ToString(), "Data found");
                        setClientForm(c);
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Exception Occurred");
            }
        }

        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
