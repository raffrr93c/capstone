﻿using System;
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
        Order order = new Order();

        public CreateOrder()
        {
            InitializeComponent();
            DbMgr db = new DbMgr();
            List<Customer> clients = db.getCustomers();
            foreach (Customer c in clients)
            {
                cmbClients.Items.Add(c.getId() + ": " + c.getFirstName() + " " + c.getLastName());
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbMgr db = new DbMgr();
                String cmbVal = cmbClients.SelectedValue.ToString();
                String[] pieces = cmbVal.Split(':');

                order.setCustomerId(Int32.Parse(pieces[0]));
                order.setNumberOfDeer(Int32.Parse(txtNumDeer.Text));
                order.setPickupDate(PickUpDate.DisplayDate);
                order.setDropoffDate(DropOffDate.DisplayDate);
                if (db.saveOrder(order))
                {
                    Dashboard dash = new Dashboard();
                    dash.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Creation of Order failed!", "Failure!");
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

        private void cmbClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtWeight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void clearDeerFields()
        {
            txtSteak.Text = "";
            txtSausage.Text = "";
            txtJerky.Text = "";
            txtBurger.Text = "";
            txtWeight.Text = "";
            txtTagNumber.Text = "";
        }

        private void btnIntakeDeer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Deer deer = new Deer();
                deer.setBurgerWeight(float.Parse(txtBurger.Text));
                deer.setJerkyWeight(float.Parse(txtJerky.Text));
                deer.setSausageWeight(float.Parse(txtSausage.Text));
                deer.setSteakWeight(float.Parse(txtSteak.Text));
                deer.setTagNumber(int.Parse(txtTagNumber.Text));
                deer.setWeight(float.Parse(txtWeight.Text));
                order.addDeer(deer);
                clearDeerFields();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Exception Occurred");
            }
        }
    }
}
