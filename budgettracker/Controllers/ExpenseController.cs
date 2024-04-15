
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

        /*---------UPDATE NEW EXPENSE----------

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]

    public ActionResult UpdateExpense(Expenses expense){

    }

        /*---------DELETE NEW EXPENSE----------

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]

    // Add expense
    public string DeleteExpense(Expenses expense){

    }

*/

}
