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

namespace DeerCuts.Orders
{
    /// <summary>
    /// Interaction logic for FindOrder.xaml
    /// </summary>
    public partial class FindOrder : Window
    {
        public FindOrder()
        {
            InitializeComponent();
            DbMgr db = new DbMgr();
            List<Customer> clients = db.getCustomers();
            foreach (Customer c in clients)
            {
                cmbClients.Items.Add(c.getId() + ": " + c.getFirstName() + " " + c.getLastName());
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnLookupOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbMgr db = new DbMgr();
                List<Order> orders = db.getOrders();
                bool hasMatch = false;

                foreach (Order o in orders)
                {
                    if (o.getNumberOfDeer() == Int32.Parse(txtNumDeer.Text))
                    {
                        hasMatch = true;
                    }
                    string[] parts = cmbClients.SelectedItem.ToString().Split(':');
                    string customer = parts[0];
                    if (o.getCustomerId() == Int32.Parse(customer))
                    {
                        hasMatch = true;
                    }
                }
                if (!hasMatch)
                {
                    MessageBox.Show("match not found", "No Data Found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception Occurred", exc.ToString());
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
