using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StatePattern
{
    public class CustomerContext
    {
        private IState _state;

        private decimal _balance;
        public decimal Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }

        public CustomerContext()
        {
            _state = new NewState();
        }

        public void SetState(IState state) => _state = state;
        public IState GetState() => _state;

        public void Request(decimal amount) => _state.Action(this, amount);

        public void Discount(decimal amount) => _balance -= amount;
    }
}
