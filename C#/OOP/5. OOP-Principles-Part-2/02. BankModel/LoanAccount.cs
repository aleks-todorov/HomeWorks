using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankModel
{
    class LoanAccount : Account
    {
        public LoanAccount(AccountHolder customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int monthsPeriod)
        {
            if (this.Customer == AccountHolder.Individual)
            {
                monthsPeriod -= 3;
            }
            else
            {
                monthsPeriod -= 2;
            }

            decimal interest = monthsPeriod * this.InterestRate;
            return interest;

        }


        public override void WithDraw(decimal sum)
        {
            Console.WriteLine("Loan Accounts can not withdraw money!");
        }
    }
}
