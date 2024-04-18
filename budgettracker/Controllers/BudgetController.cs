
using budgettracker;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class BudgetController : Controller
{
    private readonly SummaryService _service;

    public BudgetController(SummaryService service){
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetSummary()
    {   
     return Json(_service.GetSummary());
    }

     [HttpGet("expenseTypes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetTypes()
    {   
     return Json(_service.GetExpensesCategories());
    }

    [HttpGet("incomeTypes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetIncomeCategories()
    {   
     return Json(_service.GetIncomeCategories());
    }
}
