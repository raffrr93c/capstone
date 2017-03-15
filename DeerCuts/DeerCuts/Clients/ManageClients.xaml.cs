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
using DeerCuts.Clients;

namespace DeerCuts
{
    /// <summary>
    /// Interaction logic for ManageClients.xaml
    /// </summary>
    public partial class ManageClients : Window
    {
        public ManageClients()
        {
            InitializeComponent();
        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateClient create = new CreateClient();
                create.Show();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception Occurred", exc.ToString());
            }

        }

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateClient update = new UpdateClient();
                update.Show();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception Occurred", exc.ToString());
            }
           
        }

        private void btnFindClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FindClient find = new FindClient();
                find.Show();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception Occurred", exc.ToString());
            }

        }
    }
}
