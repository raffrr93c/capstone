using System.Windows;
using DeerCuts.Orders;
using DeerCuts.Clients;

namespace DeerCuts
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public ManageOrders orders { get; private set; }
        public ManageClients clients { get; private set; }
        public GenerateReports reports { get; private set; }

        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnManageOrders_Click(object sender, RoutedEventArgs e)
        {
            this.orders = new ManageOrders();
            this.orders.Show();
            this.Close();
        }

        private void btnManageClients_Click(object sender, RoutedEventArgs e)
        {
            this.clients = new ManageClients();
            this.clients.Show();
            this.Close();
        }

        private void btnGenerateReports_Click(object sender, RoutedEventArgs e)
        {
            this.reports = new GenerateReports();
            this.reports.Show();
            this.Close();
        }
    }
}
