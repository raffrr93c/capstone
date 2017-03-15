using System;

public class Employee
{
    private int employeeId;
    private string employeeLastName;
    private string employeeFirstName;
    private int employeePin;

    public Employee()
	{
	}

    public int getId()
    {
        return this.employeeId;
    }

    public void setId(int id)
    {
        this.employeeId = id;
    }

    public string getLastName()
    {
        return this.employeeLastName;
    }

    public void setLastName(string lastName)
    {
        this.employeeLastName = lastName;
    }

    public string getFirstName()
    {
        return this.employeeFirstName;
    }

    public void setFirstName(string firstName)
    {
        this.employeeFirstName = firstName;
    }

    public int getPin()
    {
        return this.employeePin;
    }

    public void setPin(int pin)
    {
        this.employeePin = pin;
    }
}