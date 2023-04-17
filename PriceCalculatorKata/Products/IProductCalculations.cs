using PriceCalculatorKata.Caps;
using PriceCalculatorKata.Expenses;

namespace PriceCalculatorKata.Products
{
    public interface IProductCalculations
    {
        decimal AfterTaxDiscountsAmount(decimal BeforeTax);
        decimal BeforeTaxDiscountsAmount();
        decimal CapAmount(Cap cap);
        decimal DiscountPrecentageMultiply(DiscountType DiscountType);
        decimal DiscountPrecentageSum(DiscountType DiscountType);
        decimal ExpenseAmount(Expense Expense);
        decimal FinalPrice();
        decimal GetCap();
        decimal GetTax(decimal BeforeApplyingTaxDiscounts);
        decimal GetTotalDiscount();
        decimal GetTotalExpenses();
        decimal GetTotalTax();
        decimal MaximunDiscount();
        decimal TaxPrecentageSum();
    }
}