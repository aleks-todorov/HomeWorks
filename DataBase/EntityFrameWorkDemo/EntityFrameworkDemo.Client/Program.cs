using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkDemo.Models;

namespace EntityFrameworkDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.Where(c => c.Country == "UK")
                .OrderBy(x => x.ContactName)
                .Where(x => x.City == "London")
                .Select(x => x.Address);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
    }
}
