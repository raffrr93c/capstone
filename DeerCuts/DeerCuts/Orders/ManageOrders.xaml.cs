using DeerCuts.Orders;
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
    /// Interaction logic for ManageOrders.xaml
    /// </summary>
    public partial class ManageOrders : Window
    {
        public ManageOrders()
        {
            InitializeComponent();
        }

        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder createOrder = new CreateOrder();
            createOrder.Show();
            this.Close();
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrder update = new UpdateOrder();
            update.Show();
            this.Close();
        }

        private void btnCheckOrder_Click(object sender, RoutedEventArgs e)
        {
            FindOrder find = new FindOrder();
            find.Show();
            this.Close();
        }
    }
}
