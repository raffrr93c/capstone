using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


public class DbMgr
{
    private static string databaseName = "rothdeerdb";
    private static string databaseUserName = "capstoneuser";
    private static string databasePassword = "chohatesjava";
    private static string databaseUrl = "mysql.joshthetechguy.tech";
    private string databaseConnectionString = "SERVER=" + databaseUrl + ";DATABASE=" + databaseName + ";UID=" + databaseUserName +
                                              ";PASSWORD=" + databasePassword + ";";
    private MySqlConnection connection = null;

    public DbMgr() { }

    private bool connect()
    {
        try
        {
            connection = new MySqlConnection(databaseConnectionString);
            connection.Open();
            if (connection != null)
                return true;
            else
                return false;
        }
        catch (MySqlException exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred Connection Failed");
            return false;
        }

    }

    public bool close()
    {
        try
        {
            if (connection != null)
                connection.Close();
            else
                return true;
            if (connection == null)
                return true;
            else
                return false;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }

    }

    public bool deleteEmployee(Employee employee)
    {
        try
        {
            MySqlDataReader employeeFromDb = null;
            this.connect();
            if (connection != null)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM User WHERE user_id=@userid";
                command.Prepare();
                command.Parameters.AddWithValue("@userid", employee.getId());
                employeeFromDb = command.ExecuteReader();
            }
            else
            {
                this.close();
                return false;
            }
            if (employeeFromDb.Depth != 0)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM User WHERE user_id=@userid";
                command.Prepare();
                command.Parameters.AddWithValue("@userid", employee.getId());
                command.ExecuteNonQuery();
                this.close();
                return true;
            }
            else
            {
                this.close();
                return false;
            }
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }

    }

    public bool saveOrder(Order order)
    {
        try
        {
            MySqlCommand command = null;
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO `Order` (order_id, number_of_deer, order_status, customer_id, total, pickup_date, dropoff_date) VALUES (@orderid, @numberofdeer, @orderstatus, @customerid, @total, @pickup, @dropoff)";
            command.Prepare();
            command.Parameters.AddWithValue("@orderid", order.getId());
            command.Parameters.AddWithValue("@numberofdeer", order.getNumberOfDeer());
            command.Parameters.AddWithValue("@orderstatus", order.getComplete());
            command.Parameters.AddWithValue("@customerid", order.getCustomerId());
            command.Parameters.AddWithValue("@total", order.getOrderTotal());
            command.Parameters.AddWithValue("@pickup", order.getPickupDate());
            command.Parameters.AddWithValue("@dropoff", order.getDropoffDate());
            command.ExecuteNonQuery();
            this.close();

            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM `Order` WHERE number_of_deer=@numberofdeer and order_status=@orderstatus and customer_id=@customerid and total=@total and pickup_date=@pickup and dropoff_date=@dropoff";
            command.Prepare();
            command.Parameters.AddWithValue("@orderid", order.getId());
            command.Parameters.AddWithValue("@numberofdeer", order.getNumberOfDeer());
            command.Parameters.AddWithValue("@orderstatus", order.getComplete());
            command.Parameters.AddWithValue("@customerid", order.getCustomerId());
            command.Parameters.AddWithValue("@total", order.getOrderTotal());
            command.Parameters.AddWithValue("@pickup", order.getPickupDate());
            command.Parameters.AddWithValue("@dropoff", order.getDropoffDate());
            MySqlDataReader orderFromTable = command.ExecuteReader();
            orderFromTable.Read();
            int orderID = orderFromTable.GetInt32(0);
            this.close();

            System.Windows.MessageBox.Show(orderID.ToString(), "ORDER");
            foreach (Deer deer in order.getDeerList())
            {
                saveDeer(deer);
                assocDeerOrder(deer, orderID);
            }
            
            return true;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }
    }

    public bool assocDeerOrder(Deer deer, int order)
    {
        try
        {
            MySqlCommand command = null;
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO DeerInOrder (deer_id, order_id) VALUES (@deerid, @order_id)";
            command.Prepare();
            command.Parameters.AddWithValue("@deerid", deer.getTagNumber());
            command.Parameters.AddWithValue("@order_id", order);
            command.ExecuteNonQuery();
            this.close();
            return true;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }
    }

    public bool saveDeer(Deer deer)
    {
        try
        {
            MySqlCommand command = null;
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Deer (deer_id, jerky_weight, burger_weight, sausage_weight, steak_weight, weight) VALUES (@deerid, @jerky, @burger, @sausage, @steak, @weight)";
            command.Prepare();
            command.Parameters.AddWithValue("@deerid", deer.getTagNumber());
            command.Parameters.AddWithValue("@weight", deer.getWeight());
            command.Parameters.AddWithValue("@jerky", deer.getJerkyWeight());
            command.Parameters.AddWithValue("@burger", deer.getBurgerWeight());
            command.Parameters.AddWithValue("@sausage", deer.getSausageWeight());
            command.Parameters.AddWithValue("@steak", deer.getSteakWeight());
            command.ExecuteNonQuery();
            this.close();
            return true;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }
    }

    public bool saveCustomer(Customer customer)
    {
        try
        {
            MySqlCommand command = null;
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Customer (customer_id, customer_last_name, customer_first_name, customer_email, customer_address, customer_phone, customer_license, customer_login, customer_password) VALUES (@customerid, @customerlastname, @customerfirstname, @customeremail, @customeraddress, @customerphone, @customerlicense, @customerlogin, @customerpass)";
            command.Prepare();
            command.Parameters.AddWithValue("@customerid", customer.getId());
            command.Parameters.AddWithValue("@customerlastname", customer.getLastName());
            command.Parameters.AddWithValue("@customerfirstname", customer.getFirstName());
            command.Parameters.AddWithValue("@customeremail", customer.getEmail());
            command.Parameters.AddWithValue("@customeraddress", customer.getAddress());
            command.Parameters.AddWithValue("@customerphone", customer.getPhoneNumber());
            command.Parameters.AddWithValue("@customerlicense", customer.getLicenseNumber());
            command.Parameters.AddWithValue("@customerlogin", customer.getLogin());
            command.Parameters.AddWithValue("@customerpass", customer.getPassword());
            command.ExecuteNonQuery();
            this.close();
            return true;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }
    }

    public bool saveEmployee(Employee employee)
    {
        try
        {
            MySqlCommand command = null;
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Employee (employee_id, employee_last_name, employee_first_name, employee_pin) VALUES (@employeeid, @employeelastname, @employeefirstname, @employeepin)";
            command.Prepare();
            command.Parameters.AddWithValue("@employeeid", employee.getId());
            command.Parameters.AddWithValue("@employeelastname", employee.getLastName());
            command.Parameters.AddWithValue("@employeefirstname", employee.getFirstName());
            command.Parameters.AddWithValue("@employeepin", employee.getPin());
            command.ExecuteNonQuery();
            this.close();
            return true;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }

    }

    public List<Customer> getCustomers()
    {
        try
        {
            MySqlDataReader customersFromDb = null;
            MySqlCommand command = null;
            this.connect();
            if (connection != null)
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Customer";
                command.Prepare();
                customersFromDb = command.ExecuteReader();

            }
            List<Customer> tempCustomers = new List<Customer>();
            while (customersFromDb.Read())
            {
                Customer tempCustomer = new Customer();
                tempCustomer.setId(customersFromDb.GetInt32(0));
                tempCustomer.setLastName(customersFromDb.GetString(1));
                tempCustomer.setFirstName(customersFromDb.GetString(2));
                tempCustomer.setEmail(customersFromDb.GetString(3));
                tempCustomer.setAddress(customersFromDb.GetString(4));
                tempCustomer.setPhoneNumber(customersFromDb.GetString(5));
                tempCustomer.setLicenseNumber(customersFromDb.GetString(6));
                tempCustomer.setLogin(customersFromDb.GetString(7));
                tempCustomer.setPassword(customersFromDb.GetString(8));
                tempCustomers.Add(tempCustomer);
            }
            this.close();
            return tempCustomers;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred Retrieval");
            return new List<Customer>();
        }

    }

    public List<Employee> getEmployees()
    {
        try
        {
            MySqlDataReader employeesFromDb = null;
            if (connection != null)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Employee";
                command.Prepare();
                employeesFromDb = command.ExecuteReader();
            }
            List<Employee> tempEmployees = new List<Employee>();
            while (employeesFromDb.Read())
            {
                Employee tempEmployee = new Employee();
                tempEmployee.setId(employeesFromDb.GetInt32(0));
                tempEmployee.setLastName(employeesFromDb.GetString(1));
                tempEmployee.setFirstName(employeesFromDb.GetString(2));
                tempEmployee.setPin(employeesFromDb.GetInt32(3));
            }
            return tempEmployees;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return new List<Employee>();
        }
    }

    public List<Order> getOrders()
    {
        try
        {
            this.connect();
            MySqlDataReader ordersFromDb = null;
            if (connection != null)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `Order`";
                ordersFromDb = command.ExecuteReader();
            }
            else
            {
                return new List<Order>();
            }
            List<Order> tempOrders = new List<Order>();
            while (ordersFromDb.Read())
            {
                Order tempOrder = new Order();
                tempOrder.setId(ordersFromDb.GetInt32(0));
                tempOrder.setNumberOfDeer(ordersFromDb.GetInt32(1));
                tempOrder.setCustomerId(ordersFromDb.GetInt32(3));
                tempOrder.setPickupDate(ordersFromDb.GetDateTime(5));
                tempOrder.setDropoffDate(ordersFromDb.GetDateTime(6));
            }
            return tempOrders;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return new List<Order>();
        }
    }

    public List<Deer> getDeer()
    {
        try
        {
            MySqlDataReader deerFromDb = null;
            if (connection != null)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT deer_id, jerky_weight, burger_weight,  sausage_weight, steak_weight FROM Deer";
                command.Prepare();
                deerFromDb = command.ExecuteReader();
            }
            List<Deer> tempDeers = new List<Deer>();
            while (deerFromDb.Read())
            {
                Deer tempDeer = new Deer();
                tempDeer.setTagNumber (deerFromDb.GetInt32(0));
                tempDeer.setJerkyWeight(deerFromDb.GetFloat(1));
                tempDeer.setBurgerWeight(deerFromDb.GetFloat(2));
                tempDeer.setSausageWeight(deerFromDb.GetFloat(3));
                tempDeer.setSteakWeight(deerFromDb.GetFloat(4));
            }
            return tempDeers;
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return new List<Deer>();
        }

    }

    public bool updateCustomer(Customer customer)
    {
        try
        {
            MySqlDataReader customerFromDb = null;
            MySqlCommand command = null;
            this.connect();
            if (connection != null)
            {

                command = connection.CreateCommand();
                command.CommandText = "UPDATE Customer SET customer_last_name=@lastname, customer_first_name=@firstname, customer_email=@email, customer_address=@address, customer_phone=@phone, customer_license=@license, customer_login=@login, customer_password=@password WHERE customer_id=@customerid";
                command.Prepare();
                command.Parameters.AddWithValue("@customerid", customer.getId());
                command.Parameters.AddWithValue("@firstname", customer.getFirstName());
                command.Parameters.AddWithValue("@lastname", customer.getLastName());
                command.Parameters.AddWithValue("@phone", customer.getPhoneNumber());
                command.Parameters.AddWithValue("@address", customer.getAddress());
                command.Parameters.AddWithValue("@email", customer.getEmail());
                command.Parameters.AddWithValue("@license", customer.getLicenseNumber());
                command.Parameters.AddWithValue("@login", customer.getLogin());
                command.Parameters.AddWithValue("@password", customer.getPassword());
                customerFromDb = command.ExecuteReader();
                command.Dispose();
                return true;
            }
            else
            {
                this.close();
                return false;
            }
        }
        catch (Exception exc)
        {
            System.Windows.MessageBox.Show(exc.ToString(), "Exception Occurred");
            return false;
        }

    }
}