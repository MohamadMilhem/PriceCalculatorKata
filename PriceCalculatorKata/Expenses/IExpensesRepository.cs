namespace PriceCalculatorKata.Expenses
{
    public interface IExpensesRepository
    {
        List<Expense> GetAll();
        IEnumerable<Expense> GetExpensesByUPC(long UPC);
    }
}