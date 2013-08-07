using Northwind.Data;

class Program
{
    /* 7. Try to open two different data contexts and perform concurrent changes on the same records. 
     * What will happen at SaveChanges()? How to deal with it? */

    static void Main(string[] args)
    {
        var conOne = new NorthwindEntities();

        using (conOne)
        {
            var conTwo = new NorthwindEntities();

            using (conTwo)
            {
                var customerOne = conOne.Customers.Find("ALFKI");
                var customerTwo = conTwo.Customers.Find("ALFKI");

                customerOne.ContactName = "Maria Anders Modified";
                customerTwo.ContactName = "Maria Anders Eddited";

                conOne.SaveChanges();
                conTwo.SaveChanges();
            }
        }
    }
}


