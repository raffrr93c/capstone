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

    public bool save(Object obj)
    {
        try
        {
            if (Object.ReferenceEquals(obj.GetType(), typeof(Customer)))
                return saveCustomer((Customer)obj);
            if (Object.ReferenceEquals(obj.GetType(), typeof(Employee)))
                return saveEmployee((Employee)obj);
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

    private bool saveOrder(Order order)
    {
        try
        {
            MySqlDataReader orderFromDb = null;
            MySqlCommand command = null;
            this.connect();
            if (connection != null)
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `Order` WHERE order_id=@orderid";
                command.Prepare();
                command.Parameters.AddWithValue("@orderid", order.getId());
                orderFromDb = command.ExecuteReader();
            }
            else
            {
                this.close();
                return false;
            }
            if (orderFromDb.Depth != 0)
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM `Order` WHERE order_id=@orderid";
                command.Prepare();
                command.Parameters.AddWithValue("@orderid", order.getId());
                command.ExecuteNonQuery();
                orderFromDb.Close();
                this.close();
            }
            foreach (Deer deer in order.getDeerList())
            {
                saveDeer(deer);
            }
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO `Order` (order_id, number_of_deer, order_status, customer_id) VALUES (@orderid, @numberofdeer, @orderstatus, @customerid)";
            command.Prepare();
            command.Parameters.AddWithValue("@orderid", order.getId());
            command.Parameters.AddWithValue("@numberofdeer", order.getNumberOfDeer());
            command.Parameters.AddWithValue("@orderstatus", order.getComplete());
            command.Parameters.AddWithValue("@customerid", order.getCustomerId());
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

    private bool saveDeer(Deer deer)
    {
        try
        {
            MySqlDataReader deerFromDb = null;
            MySqlCommand command = null;
            this.connect();
            if (connection != null)
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Deer WHERE deer_id=@deerid";
                command.Prepare();
                command.Parameters.AddWithValue("@deerid", deer.getTagNumber());
                deerFromDb = command.ExecuteReader();
            }
            else
            {
                this.close();
                return false;
            }
            if (deerFromDb.Depth != 0)
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Deer WHERE deer_id=@deerid";
                command.Prepare();
                command.Parameters.AddWithValue("@deerTagNumber", deer.getTagNumber());
                command.ExecuteNonQuery();
                deerFromDb.Close();
                this.close();
            }
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Deer (deer_id, deer_extra_cost, deer_special_cut, deer_instructions) VALUES (@deerid, @deerextracost, @deerspecialcut, @deerinstructions)";
            command.Prepare();
            command.Parameters.AddWithValue("@deerid", deer.getTagNumber());
            command.Parameters.AddWithValue("@deerextracost", deer.getExtraCost());
            command.Parameters.AddWithValue("@deerspecialcut", deer.getSpecialCut());
            command.Parameters.AddWithValue("@deerinstructions", deer.getInstructions());
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

    private bool saveCustomer(Customer customer)
    {
        try
        {
            MySqlDataReader customerFromDb = null;
            MySqlCommand command = null;
            this.connect();
            if (connection != null)
            {

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Customer WHERE customer_id=@customerid";
                command.Prepare();
                command.Parameters.AddWithValue("@customerid", customer.getId());
                customerFromDb = command.ExecuteReader();
                command.Dispose();
            }
            else
            {
                this.close();
                return false;
            }
            if (customerFromDb.Depth != 0)
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Customer WHERE customer_id=@customerid";
                command.Prepare();
                command.Parameters.AddWithValue("@customerid", customer.getId());
                command.ExecuteReader();
                command.Dispose();
                customerFromDb.Close();
                this.close();
            }
            foreach (Order order in customer.getOrderList())
            {
                saveOrder(order);
            }
            this.connect();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Customer (customer_id, customer_last_name, customer_first_name, customer_email, customer_address, customer_phone, customer_license, customer_login, customer_password) VALUES (@customerid, @customerfirstname, @customerlastname, @customeremail, @customeraddress, @customerphone, @customerlicense, @customerlogin, @customerpass)";
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

    private bool saveEmployee(Employee employee)
    {
        try
        {
            MySqlDataReader employeeFromDb = null;
            MySqlCommand command = null;
            this.connect();
            if (connection != null)
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Employee WHERE employee_id=@employeeid";
                command.Prepare();
                command.Parameters.AddWithValue("@employeeid", employee.getId());
                employeeFromDb = command.ExecuteReader();
            }
            else
            {
                this.close();
                return false;
            }
            if (employeeFromDb.Depth != 0)
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Employee WHERE employee_id=@employeeid";
                command.Prepare();
                command.Parameters.AddWithValue("@employeeid", employee.getId());
                command.ExecuteNonQuery();
            }
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
            MySqlDataReader ordersFromDb = null;
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
            MySqlDataReader ordersFromDb = null;
            if (connection != null)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Order";
                command.Prepare();
                ordersFromDb = command.ExecuteReader();
            }
            List<Order> tempOrders = new List<Order>();
            while (ordersFromDb.Read())
            {
                Order tempOrder = new Order();
                tempOrder.setId(ordersFromDb.GetInt32(0));
                tempOrder.setNumberOfDeer(ordersFromDb.GetInt32(1));
                tempOrder.setComplete(ordersFromDb.GetBoolean(2));
                tempOrder.setCustomerId(ordersFromDb.GetInt32(3));
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
                command.CommandText = "SELECT * FROM Deer";
                command.Prepare();
                deerFromDb = command.ExecuteReader();
            }
            List<Deer> tempDeers = new List<Deer>();
            while (deerFromDb.Read())
            {
                Deer tempDeer = new Deer();
                tempDeer.setTagNumber (deerFromDb.GetInt32(0));
                tempDeer.setExtraCost(deerFromDb.GetFloat(1));
                tempDeer.setSpecialCut(deerFromDb.GetString(2));
                tempDeer.setInstructions(deerFromDb.GetString(3));
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