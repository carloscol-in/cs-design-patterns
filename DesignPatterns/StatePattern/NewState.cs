using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StatePattern
{
    public class NewState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine($"Se le pone {amount} a su saldo");
            customerContext.Balance = amount;
            customerContext.SetState(new NotDebtorState());
        }
    }
}
