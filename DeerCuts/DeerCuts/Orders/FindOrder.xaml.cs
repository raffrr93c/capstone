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
        }



        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbMgr db = new DbMgr();
                List<Order> orders = db.getOrders();
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
