using System;
using System.Linq;
using Northwind.Data;

public static class DBFunction
{
    public static void Add(string id, string companyName, string contactomerName)
    {
        var northwindEntities = new NorthwindEntities();
        Customer newCustomer = new Customer
        {
            CustomerID = id,
            CompanyName = companyName,
            ContactName = contactomerName
        };
        northwindEntities.Customers.Add(newCustomer);
        northwindEntities.SaveChanges();
        Console.WriteLine("Customer successfully successfully created");
    }

    public static void Delete(string id)
    {
        var northwindEntities = new NorthwindEntities();
        Customer customer = northwindEntities.Customers.FirstOrDefault(
           c => c.CustomerID == id);
        northwindEntities.Customers.Remove(customer);
        northwindEntities.SaveChanges();
        Console.WriteLine("Customer with ID: {0} successfully removed! ", id);
    }

    public static void Update(string id, string companyName)
    {
        var northwindEntities = new NorthwindEntities();
        Customer customer = northwindEntities.Customers.FirstOrDefault(
           c => c.CustomerID == id);
        customer.CompanyName = companyName;
        northwindEntities.SaveChanges();
        Console.WriteLine("Customer with id: {0} successfully eddited", id);
    }

    public static void ListAll()
    {
        using (var db = new NorthwindEntities())
        {
            var customers = db.Customers.ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine("ID: {0}, ComplanyName: {1}, ContactName: {2}",
                    customer.CustomerID, customer.CompanyName, customer.ContactName);
            }
        }
    }
}

