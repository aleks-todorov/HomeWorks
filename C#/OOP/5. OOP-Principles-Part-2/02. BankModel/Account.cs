using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankModel
{
    abstract class Account : ICalculateInterest, IMoneyOperationable
    {
        private AccountHolder customer;
        private decimal balance;
        private decimal interestRate;

        protected AccountHolder Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        protected decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        protected decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        protected Account(AccountHolder customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public virtual decimal CalculateInterest(int monthsPeriod)
        {
            decimal interest = this.InterestRate * monthsPeriod;
            return interest;
        }

        public virtual void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public virtual void WithDraw(decimal sum)
        {
            this.Balance -= sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nAccount Holder: " + this.Customer);
            sb.Append("\nAccount Balance: " + this.Balance);
            sb.Append("\nAccount Interest Rate: " + this.InterestRate);

            return sb.ToString();
        }
    }
}
