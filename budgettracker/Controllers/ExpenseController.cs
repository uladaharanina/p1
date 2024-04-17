
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using budgettracker.data;
using Microsoft.EntityFrameworkCore;

namespace budgettracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController: Controller
{
    //Inject repo
    private readonly BudgetRepository repo;

    public ExpenseController(BudgetRepository repo)
    {
        this.repo = repo;
    }

    /*---------LIST ALL EXPENSES----------*/
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Expenses> GetExpenses(){
        //return "TEST";

       return repo.ListExpenses();
    }


    /*---------ADD NEW EXPENSE----------*/

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult  AddExpense(Expenses expense){

        if(ModelState.IsValid)
        {
            repo.AddExpense(expense);
            return CreatedAtAction(nameof(AddExpense), new { id = expense.ExpenseId }, expense);
        }
        else{
            return BadRequest(ModelState);
        }
    }

        /*---------UPDATE NEW EXPENSE----------*/

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]

    public ActionResult UpdateExpense(Expenses expense){

        //Find id of the expense
        Expenses expenseToUpdate = repo.GetExpenseById(expense);
        if(expenseToUpdate != null){
        //Update values
                expenseToUpdate.Amount = expense.Amount;
                expenseToUpdate.Name = expense.Name;
                expenseToUpdate.Type = expense.Type;

                if(ModelState.IsValid)
                {
                    repo.UpdateExpense(expenseToUpdate);
                    return CreatedAtAction(nameof(UpdateExpense), new { id = expenseToUpdate.ExpenseId }, expenseToUpdate);
                }
                else{
                    return BadRequest(ModelState);
                }
        }
        else{
                return NotFound("Expense not found");

        }

       
    }

    /*---------DELETE NEW EXPENSE----------*/

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> DeleteExpense(Expenses expense){
 //Find id of the expense
        Expenses expenseToDelete = repo.GetExpenseById(expense);
        if(expenseToDelete != null){
            repo.DeleteExpense(expenseToDelete);
            return $"Expense {expense.Name} was deleted";
        }
        else{
            return $"Expense does not exist";
        }
    }


    /*-----------SUMAMRY EXPENSES-----------*/

    [HttpGet("total-expenses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<object> GetTotalExpenses(){
        
        //Get all expenses and calculate total, what is the most spending go to
        IEnumerable<Expenses> myExpenses = repo.ListExpenses();

        double totalExpenses = 0;
        double theMostExpensivePurchasePrice = myExpenses.Max(expense => expense.Amount);
        string theMostExpensivePurchaseName = myExpenses
                                                .Where(expense => expense.Amount == theMostExpensivePurchasePrice)
                                                .Select(expenses => expenses.Name)
                                                .FirstOrDefault();

        var ExpensesTypes = myExpenses.GroupBy(expense => expense.Type)
                                                    .Select(group => new{
                                                        Type = group.Key,
                                                        typetotal = group.Sum(expense => expense.Amount)
                                                       });
        var BiggestSourceOfLoss = ExpensesTypes.OrderByDescending(expense => expense.typetotal);

        //Define all expenses
        myExpenses.ToList().ForEach(expense => totalExpenses += expense.Amount);

        //Define most expensive purchase

        //Define what category has the most spedning
        
        var expenseSummary = new {
            TotalExpenses = "$" + totalExpenses.ToString(),
            TheBiggestSpedningAmount = theMostExpensivePurchasePrice,
            TheBiggestSpedningPurchaseName = theMostExpensivePurchaseName
            
            };

        return Json(expenseSummary);
    }
}
