using System;
using System.Text;

public class Article : IComparable
{
    public string Barcode { get; set; }
    public string Vendor { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }

    public Article(string barcode, string vendor, string title, double price)
    {
        this.Barcode = barcode;
        this.Vendor = vendor;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("Barcode: {0}\n", this.Barcode);
        sb.AppendFormat("Vendor: {0}\n", this.Vendor);
        sb.AppendFormat("Title: {0}\n", this.Title);
        sb.AppendFormat("Price: {0:f2}\n", this.Price);
        return sb.ToString();
    }

    public int CompareTo(object obj)
    {
        var otherArticle = obj as Article;
        if (this.Price == otherArticle.Price)
        {
            return 0;
        }
        else if (this.Price > otherArticle.Price)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
