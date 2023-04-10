namespace PriceCalculatorKata.Expenses
{
    public interface IExpense
    {
        decimal Amount { get; set; }
        string Description { get; set; }
        ExpenseType Type { get; set; }
        long ProductUPC { get; set; }

    }
}