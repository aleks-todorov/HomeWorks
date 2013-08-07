using System;
using System.Linq;
using System.Data.Linq;
using Northwind.Data;

public partial class Employee
{
    public EntitySet<Territory> EntityTerritories
    {
        get
        {
            var employeeTerritories = this.EntityTerritories;
            EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
            entityTerritories.AddRange(employeeTerritories);
            return entityTerritories;
        }
    }
}


