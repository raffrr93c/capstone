using Newtonsoft.Json;
using System;
[JsonObject]
public class Deer
{
    [JsonProperty]
    private const float deerCost = 75.0f;
    [JsonProperty]
    private int deerTagNumber;
    [JsonProperty]
    private float deerExtraCost;
    [JsonProperty]
    private string deerSpecialCut;
    [JsonProperty]
    private string deerInstructions;

	public Deer()
	{
        this.deerExtraCost = 0.0f;
	}

    public int getTagNumber()
    {
        return this.deerTagNumber;
    }

    public void setTagNumber(int tagNumber)
    {
        this.deerTagNumber = tagNumber;
    }

    public float getExtraCost()
    {
        return this.deerExtraCost;
    }

    public void setExtraCost(float extraCost)
    {
        this.deerExtraCost = extraCost;
    }

    public string getSpecialCut()
    {
        return this.deerSpecialCut;
    }

    public void setSpecialCut(string specialCut)
    {
        this.deerSpecialCut = specialCut;
    }

    public string getInstructions()
    {
        return this.deerInstructions;
    }

    public void setInstructions(string instructions)
    {
        this.deerInstructions = instructions;
    }

    public float getTotal()
    {
        float total = 0.0f;
        total += deerCost;
        total += this.getExtraCost();
        return total;
    }
}