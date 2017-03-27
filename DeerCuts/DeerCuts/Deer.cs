using Newtonsoft.Json;
using System;
[JsonObject]
public class Deer
{
    [JsonProperty]
    private int deerTagNumber;
    [JsonProperty]
    private float burgerWeight;
    [JsonProperty]
    private float jerkyWeight;
    [JsonProperty]
    private float sausageWeight;
    [JsonProperty]
    private float steakWeight;

    public Deer() {}

    public int getTagNumber()
    {
        return this.deerTagNumber;
    }

    public void setTagNumber(int tagNumber)
    {
        this.deerTagNumber = tagNumber;
    }

    public float getJerkyWeight()
    {
        return this.jerkyWeight;
    }

    public void setJerkyWeight(float jerkyWeight)
    {
        this.jerkyWeight = jerkyWeight;
    }

    public float getBurgerWeight()
    {
        return this.burgerWeight;
    }

    public void setBurgerWeight(float burgerWeight)
    {
        this.burgerWeight = burgerWeight;
    }

    public float getSteakWeight()
    {
        return this.steakWeight;
    }

    public void setSteakWeight(float steakWeight)
    {
        this.steakWeight = steakWeight;
    }

    public float getSausageWeight()
    {
        return this.sausageWeight;
    }

    public void setSausageWeight(float sausageWeight)
    {
        this.sausageWeight = sausageWeight;
    }
}