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
    /// Interaction logic for CreateDeer.xaml
    /// </summary>
    public partial class CreateDeer : Window
    {
        public CreateDeer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtBurger.Text = "";
            txtJerky.Text = "";
            txtSausage.Text = "";
            txtSteak.Text = "";
            txtWeight.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Deer deer = new Deer();
                deer.setBurgerWeight(float.Parse(txtBurger.Text));
                deer.setJerkyWeight(float.Parse(txtJerky.Text));
                deer.setSausageWeight(float.Parse(txtSausage.Text));
                deer.setSteakWeight(float.Parse(txtSteak.Text));
                DbMgr db = new DbMgr();
                if (db.saveDeer(deer))
                {
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Exception Occurred");
            }
        }
    }
}
