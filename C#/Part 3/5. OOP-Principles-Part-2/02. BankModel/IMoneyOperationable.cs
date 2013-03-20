using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankModel
{
    interface IMoneyOperationable
    {
        void Deposit(decimal sum);

        void WithDraw(decimal sum);
    }
}
