using Newtonsoft.Json;
using System;
using System.Collections.Generic;
[JsonObject(MemberSerialization.OptIn)]
public class Customer
{
    [JsonProperty]
    private int customerId;
    [JsonProperty]
    private string customerLastName;
    [JsonProperty]
    private string customerFirstName;
    [JsonProperty]
    private string customerEmail;
    [JsonProperty]
    private string customerAddress;
    [JsonProperty]
    private string customerPhoneNumber;
    [JsonProperty]
    private string customerLicenseNumber;
    [JsonProperty]
    private string customerLogin;
    [JsonProperty]
    private string customerPassword;
    [JsonProperty]
    private List<Order> customerOrders;
  

    public Customer()
	{
        customerOrders = new List<Order>();
	}

    public void setId(int Id)
    {
        this.customerId = Id;
    }

    public int getId()
    {
        return this.customerId;
    }

    public void setLastName(string lastName)
    {
        this.customerLastName = lastName;
    }
    
    public string getLastName()
    {
        return this.customerLastName;
    }

    public void setFirstName(string firstName)
    {
        this.customerFirstName = firstName;
    }

    public string getFirstName()
    {
        return this.customerFirstName;
    }

    public void setEmail(string email)
    {
        this.customerEmail = email;
    }

    public string getEmail()
    {
        return this.customerEmail.ToString();
    }

    public void setAddress(string address)
    {
        this.customerAddress = address;
    }

    public string getAddress()
    {
        return this.customerAddress.ToString();
    }

    public void setPhoneNumber(string phoneNumber)
    {
        this.customerPhoneNumber = phoneNumber;
    }

    public string getPhoneNumber()
    {
        return this.customerPhoneNumber;
    }

    public void setLicenseNumber(string licenseNumber)
    {
        this.customerLicenseNumber = licenseNumber;
    }

    public string getLicenseNumber()
    {
        return this.customerLicenseNumber;
    }

    public void setLogin(string login)
    {
        this.customerLogin = login;
    }

    public string getLogin()
    {
        return this.customerLogin;
    }

    public void setPassword(string password)
    {
        this.customerPassword = password;
    }

    public string getPassword()
    {
        return this.customerPassword;
    }

    public void addOrder(Order order)
    {
        order.setCustomerId(this.customerId);
        customerOrders.Add(order);
    }

    public List<Order> getOrderList()
    {
        return this.customerOrders;
    }

    public void setOrderList(List<Order> orderList)
    {
        this.customerOrders = orderList;
    }
}