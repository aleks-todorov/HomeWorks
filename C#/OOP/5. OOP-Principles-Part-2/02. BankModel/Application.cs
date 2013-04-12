using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankModel
{
    class Application
    {
        static void Main(string[] args)
        {
            //Creating Deposit Account for Individual
            DepositAccount depositAccount = new DepositAccount(AccountHolder.Individual, 1543.34m, 0.76m);
            depositAccount.Deposit(546.53m);
            Console.WriteLine(depositAccount.ToString());
            depositAccount.WithDraw(234.54m);
            Console.WriteLine(depositAccount.ToString());
            Console.WriteLine("Interest For this period is : " + depositAccount.CalculateInterest(14));

            //Creating Loan Account for Company
            LoanAccount loanAccount = new LoanAccount(AccountHolder.Company, 34565464.34m, 1.2m);
            loanAccount.Deposit(23444.34m);
            Console.WriteLine(loanAccount.ToString());
            loanAccount.WithDraw(3434.32m);
            Console.WriteLine("Interest For this period is : " + loanAccount.CalculateInterest(2));

            //Creating Mortage account for Company
            MortageAccount mortageAccount = new MortageAccount(AccountHolder.Company, 3244343.34m, 1.32m);
            mortageAccount.Deposit(23445.34m);
            Console.WriteLine(mortageAccount.ToString());
            mortageAccount.WithDraw(2343.34m);
            Console.WriteLine("Interest For this period is : " + mortageAccount.CalculateInterest(18));
        }
    }
}
