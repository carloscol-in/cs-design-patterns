using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StatePattern
{
    public class NotDebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            if(amount <= customerContext.Balance)
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Solicitud es permitida. Gastando {amount}. Le queda de saldo: {customerContext.Balance}");

                if(customerContext.Balance <= 0)
                    customerContext.SetState(new DebtorState());
            }
            else
            {
                Console.WriteLine($"No ajustas lo solicitado. Ya que tienes {customerContext.Balance}, y estas queriendo gastar {amount}");
            }
        }
    }
}
