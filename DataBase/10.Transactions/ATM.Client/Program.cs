using System;
using System.Linq;
using ATM.Models;
using System.Transactions;

namespace ATM.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new CardAccount();
            account.CardNumber = "9876543";
            account.CardPin = "22222";
            decimal transactionMoney = 500;

            var tran = new TransactionScope();
            using (tran)
            {
                try
                {
                    var dbCon = new ATMEntities();

                    var card = (from c in dbCon.CardAccounts
                                where c.CardNumber == account.CardNumber
                                select c).FirstOrDefault();

                    if (card == null)
                    {
                        throw new InvalidOperationException(" Current Card does not exist! ");
                    }
                    else
                    {
                        if (account.CardPin == card.CardPin)
                        {
                            if (account.CardCash > 200 && account.CardCash - transactionMoney > 0)
                            {
                                account.CardCash -= transactionMoney;
                                dbCon.CardAccounts.Attach(account);
                                dbCon.SaveChanges();
                            }
                            else
                            {
                                throw new ArgumentException("There are not enough money in your card!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Wrong Pin! Try again!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Transaction was not completed successfully! " + ex.Message.ToString());
                }
            }
        }
    }
}
