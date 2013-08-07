using System;
using System.Linq;
using TelerikAcademy.Data;

class Program
{
    /* 2. Using Entity Framework write a query that selects all employees from 
     * the Telerik Academy database, then invokes ToList(), then selects their 
     * addresses, then invokes ToList(), then selects their towns, then invokes 
     * ToList() and finally checks whether the town is "Sofia". Rewrite the same 
     * in more optimized way and compare the performance.*/

    static void Main(string[] args)
    {
        var dbCon = new TelerikAcademyEntities();

        using (dbCon)
        {
            ////Requests made: 645
            var query = dbCon.Employees.ToList()
                .Select(a => a.Address).ToList()
                .Select(t => t.Town).ToList()
                .Where(x => x.Name == "Sofia");


            foreach (var e in query)
            {
                Console.WriteLine(e.Name);
            }

            //Requests made: 1
            var newQuery = dbCon.Employees
                 .Select(a => a.Address)
                 .Select(t => t.Town)
                 .Where(x => x.Name == "Sofia");

            foreach (var e in newQuery)
            {
                Console.WriteLine(e.Name);
            }

        }
    }
}

