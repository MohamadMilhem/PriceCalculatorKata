namespace PriceCalculatorKata.Expenses
{
    public interface IExpenses
    {
        decimal Amount { get; set; }
        string Description { get; set; }
        ExpenseType ExpenseType { get; set; }
    }
}