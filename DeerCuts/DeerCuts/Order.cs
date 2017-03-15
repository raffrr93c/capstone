using Newtonsoft.Json;
using System;
using System.Collections.Generic;
[JsonObject]
public class Order
{
    [JsonProperty]
    private int orderId;
    [JsonProperty]
    private int numberOfDeer = 0;
    [JsonProperty]
    private bool orderComplete;
    [JsonProperty]
    private List<Deer> orderDeer;

    private int customerId;
    
	public Order()
	{
        orderDeer = new List<Deer>();
        orderComplete = false;
	}

    public int getId()
    {
        return this.orderId;
    }

    public void setId(int id)
    {
        this.orderId = id;
    }

    public int getNumberOfDeer()
    {
        return this.numberOfDeer;
    }

    public void setNumberOfDeer(int qty)
    {
        this.numberOfDeer = qty;
    }

    public bool getComplete()
    {
        return this.orderComplete;
    }

    public void setComplete(bool complete)
    {
        this.orderComplete = complete;
    }

    public void addDeer(Deer deer)
    {
        orderDeer.Add(deer);
        numberOfDeer++;
    }

    public void removeDeer(Deer deer)
    {
        orderDeer.Remove(deer);
        numberOfDeer--;
    }

    public int getCustomerId()
    {
        return this.customerId;
    }

    public void setCustomerId(int id)
    {
        this.customerId = id;
    }

    public float getOrderTotal()
    {
        float total = 0.0f;
        foreach(Deer deer in orderDeer)
        {
            total += deer.getTotal();
        }
        return total;
    }

    public List<Deer> getDeerList()
    {
        return this.orderDeer;
    }
}
