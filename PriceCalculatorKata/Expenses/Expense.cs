using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Expenses
{
    public class Expense : IExpense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType Type { get; set; }
        public long ProductUPC { get; set; }


        public Expense(decimal Amount, ExpenseType Type, string Description)
        {
            this.Amount = Amount;
            this.Type = Type;
            this.Description = Description;
        }


    }
}
