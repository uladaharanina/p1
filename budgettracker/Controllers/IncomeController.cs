
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using budgettracker.data;
using Microsoft.EntityFrameworkCore;

namespace budgettracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomeController: Controller
{
    //Inject Service
    private readonly IncomeService service;

    public IncomeController(IncomeService service)
    {
        this.service = service;
    }

    /*---------LIST ALL INCOME----------*/
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Income> GetIncome(){
       return service.ListItems();
    }

    /*---------ADD NEW INCOME----------*/

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddIncome(Income income){
        Income result = service.AddItem(income);
        if(result!= null){
            return CreatedAtAction(nameof(AddIncome), new { id = result.IncomeId }, result);
        }
        else{
            return BadRequest("Could not add new income");
        }
    }

        /*---------UPDATE INCOME----------*/

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public ActionResult UpdateIncome(Income income){
        Income result = service.UpdateItem(income);
        if(result!= null){
            return CreatedAtAction(nameof(UpdateIncome), new { id = result.IncomeId }, result);
        }
        else{
            return BadRequest("Could not edit the selected income");
        }

    }

    /*---------DELETE INCOME----------*/

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> DeleteIncome(Income income){
        bool result = service.DeleteItem(income);
        if(result == true){
            return Ok("The selected income was deleted");
        }
        else{
            return BadRequest("Could not delete the selected income");
        }
    }


}
