using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankModel
{
    class DepositAccount : Account
    {
        public DepositAccount(AccountHolder customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int monthsPeriod)
        {
            decimal interest = monthsPeriod * this.InterestRate;

            if (this.Balance > 0 && this.Balance < 1000)
            {
                interest = 0;
            }

            return interest;
        }
    }
}
