using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankModel
{
    class MortageAccount : Account
    {
        public MortageAccount(AccountHolder customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override void WithDraw(decimal sum)
        {
            Console.WriteLine("Mortage Accounts can not withdraw money!");
        }

        public override decimal CalculateInterest(int monthsPeriod)
        {
            decimal interest = 0;
            if (this.Customer == AccountHolder.Company)
            {
                if (monthsPeriod <= 12)
                {
                    interest = (monthsPeriod * this.InterestRate) / 2;
                }
                else
                {
                    interest = ((12 * this.InterestRate) / 2) + ((monthsPeriod - 12) * this.InterestRate);
                }
            }
            return interest;
        }
    }
}
