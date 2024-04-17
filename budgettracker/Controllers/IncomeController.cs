
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using budgettracker.data;
using Microsoft.EntityFrameworkCore;

namespace budgettracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomeController: Controller
{
    //Inject repo
    private readonly BudgetRepository repo;

    public IncomeController(BudgetRepository repo)
    {
        this.repo = repo;
    }

    /*---------LIST ALL INCOME----------*/
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Income> GetIncome(){
       return repo.ListIncome();
    }


    /*---------ADD NEW INCOME----------*/

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddIncome(Income income){

        if(ModelState.IsValid)
        {
            repo.AddIncome(income);
            return CreatedAtAction(nameof(AddIncome), new { id = income.IncomeId }, income);
        }
        else{
            return BadRequest(ModelState);
        }
    }

        /*---------UPDATE INCOME----------*/

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public ActionResult UpdateIncome(Income income){

        //Find id of the expense
        Income incomeToUpdate = repo.GetIncomeById(income);

        //Update values
        incomeToUpdate.Name = income.Name;
        incomeToUpdate.Amount = income.Amount;
        incomeToUpdate.Type = income.Type;

         if(ModelState.IsValid)
        {
            repo.UpdateIncome(incomeToUpdate);
            return CreatedAtAction(nameof(UpdateIncome), new { id = incomeToUpdate.IncomeId }, incomeToUpdate);
        }
        else{
            return BadRequest(ModelState);
        }
    }

    /*---------DELETE INCOME----------*/

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> DeleteIncome(Income income){
 //Find id of the expense
        Income incomeToDelete = repo.GetIncomeById(income);
        if(incomeToDelete != null){
            repo.DeleteIncome(incomeToDelete);
            return $"Income {income.Name} was deleted";
        }
        else{
            return $"Income does not exist";
        }
    }


    /*-----------SUMAMRY EXPENSES-----------*/

    [HttpGet("total-income")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<object> GetTotalIncome(){
        
        //Get all income and
        IEnumerable<Income> myIncome = repo.ListIncome();

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



        var incomeSummary = new {
            TotalIncome = "$" + totalIncome.ToString(),
            BiggestSourceOfProfit = BiggestSourceOfProfit,
            HighestEarnings = HighestEarnings
            };

        return Json(incomeSummary);
    }
}
