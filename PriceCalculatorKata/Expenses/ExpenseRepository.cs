﻿using PriceCalculatorKata.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Expenses
{
    public class ExpenseRepository
    {
        private readonly List<Expense> _expenses;


        public ExpenseRepository()
        {
            _expenses = new List<Expense>()
            {
                new Expense(0.01m, ExpenseType.Percentage, "Packaging")
                {
                    ProductUPC = 12345,
                },
                new Expense(2.2m, ExpenseType.Absolute, "Transport")
                {
                    ProductUPC = 12345,
                },
            };
        }


        public List<Expense> GetAll()
        {
            return _expenses;
        }


        public IEnumerable<Expense> GetExpensesByUPC(long UPC)
        {
            return _expenses.Where(expense => expense.ProductUPC == UPC);
        }



    }
}
