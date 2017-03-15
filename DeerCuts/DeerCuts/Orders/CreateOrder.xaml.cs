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
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        public CreateOrder()
        {
            InitializeComponent();
            DbMgr db = new DbMgr();
            //List<Customer> clients = new List<Customer>();//db.getCustomers();
            //Customer cl = new Customer();
            //cl.setFirstName("Raff");
            //clients.Add(cl);
            //cmbClients.Items.Clear();
            //cmbClients.ItemsSource = clients;
            //cmbClients.DisplayMemberPath = Cu
            cmbClients.Items.Add("Raff");
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
