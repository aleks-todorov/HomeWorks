using System;
using System.Linq;
using System.Text;

public class Product
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Cost { get; set; }

    public Product(string name, int weight, int cost)
    {
        this.Name = name;
        this.Weight = weight;
        this.Cost = cost;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendFormat("Name: {0} Weight: {1} Price: {2}", this.Name, this.Weight, this.Cost);

        return sb.ToString();
    }
}

