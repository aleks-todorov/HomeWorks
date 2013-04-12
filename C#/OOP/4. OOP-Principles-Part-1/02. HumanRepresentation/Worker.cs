using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanRepresentation
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;
        private decimal moneyPerHour;

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }

        public decimal WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set { workHoursPerDay = value; }
        }

        public decimal MoneyPerHour
        {
            get { return moneyPerHour; }
            set { moneyPerHour = value; }
        }

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
            this.moneyPerHour = GetMoneyPerHour(this.WeekSalary, this.workHoursPerDay);
        }

        private decimal GetMoneyPerHour(decimal weekSalary, decimal WorkHoursPerDay)
        {
            decimal moneyPerHour = weekSalary / (workHoursPerDay * 5);
            return moneyPerHour;
        }

        public override string ToString()
        {
            return "Worker - First Name: " + this.FirstName + " Last Name: " + this.LastName + " Week Salary: " + this.weekSalary + " Money per Hour: " + this.MoneyPerHour + "$";
        }


    }
}
