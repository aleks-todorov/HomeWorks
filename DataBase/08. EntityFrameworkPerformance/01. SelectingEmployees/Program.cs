using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Data;

class Program
{
    /* 1. Using Entity Framework write a SQL query to select all employees
     * from the Telerik Academy database and later print their name, department and town. 
     * Try the both variants: with and without .Include(…). Compare the number of executed SQL
     *  statements and the performance. */

    static void Main(string[] args)
    {
        var dbCOn = new TelerikAcademyEntities();

        using (dbCOn)
        {
            //Proffiler gave 339 requests
            foreach (var s in dbCOn.Employees)
            {
                Console.WriteLine("Name: {0}, Department {1}, Town {2}", s.FirstName, s.Department.Name, s.Address.Town.Name);
            }

            //Proffiler gave 1 requests
            foreach (var e in dbCOn.Employees.Include("Department").Include("Address.Town"))
            {
                Console.WriteLine("Name: {0}, Department {1}, Town {2}", e.FirstName, e.Department.Name, e.Address.Town.Name);
            }
        }
    }
}

