using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Expenses
{
    public class Expenses
    {
        public string Description { get; set; }
        public decimal Amount { get; set; } 
        public ExpenseType ExpenseType { get; set; }

        public Expenses(decimal Amount, ExpenseType ExpenseType, string Description)
        { 
            this.Amount = Amount;
            this.ExpenseType = ExpenseType;
            this.Description = Description;
        }

    }
}
