

using budgettracker;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class BudgetController : Controller
{
    private readonly BudgetRepository BudgetRepository;

    public BudgetController(BudgetRepository BudgetRepository)
    {
        this.BudgetRepository = BudgetRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetSummary()
    {
        IEnumerable<Income> myIncome = BudgetRepository.ListIncome();
        IEnumerable<Expenses> myExpenses = BudgetRepository.ListExpenses();

        /*GET INCOME STATS*/
        double totalIncome = myIncome.Sum(income => income.Amount);
        double HighestEarnings = myIncome.Max(income => income.Amount);

        
        var categoryIncomes =  myIncome
                .GroupBy(income => income.Type)
                .Select(group => new
                {
                    Type = group.Key,
                    typetotal = group.Sum(income => income.Amount)
                });

        var BiggestSourceOfProfit = categoryIncomes.OrderByDescending(income => income.typetotal).FirstOrDefault()?.Type;



     
        /*GET EXPENSE STATS*/
        double totalExpenses = myExpenses.Sum(expense => expense.Amount);
        double theMostExpensivePurchasePrice = myExpenses.Max(expense => expense.Amount);

        var ExpensesTypes = myExpenses.GroupBy(expense => expense.Type)
                                                    .Select(group => new{
                                                        Type = group.Key,
                                                        typetotal = group.Sum(expense => expense.Amount)
                                                       });
        var BiggestSourceOfLoss = ExpensesTypes.OrderByDescending(expense => expense.typetotal);
           string theMostExpensivePurchaseName = myExpenses
                                                .Where(expense => expense.Amount == theMostExpensivePurchasePrice)
                                                .Select(expenses => expenses.Name)
                                                .FirstOrDefault();

        /*CALCULATE BUDGET*/
        double TotalBudget = totalIncome - totalExpenses;

        var BudgetSummary = new {
            TotalIncome  = "$" + totalIncome.ToString(),
            Total_Expenses = "$" + totalExpenses.ToString(),
            TopProfitSource  = BiggestSourceOfProfit,
            TopLossSource  = theMostExpensivePurchaseName,
            HighestSpedning = "$" +theMostExpensivePurchasePrice.ToString(),
            HighestEarnings = "$" + HighestEarnings.ToString(),          
            TotalBudget = "$" + TotalBudget.ToString("F2")
        };


        return Json(BudgetSummary);
    }
}