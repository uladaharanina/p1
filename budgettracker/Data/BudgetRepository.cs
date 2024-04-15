using budgettracker.data;
using Microsoft.EntityFrameworkCore;

namespace budgettracker;

public class BudgetRepository
{
    /*--Inject Context--*/

    private readonly BudgetContext _dbContext;

    public BudgetRepository(BudgetContext context)
    {
        _dbContext = context;
    }

    /*--------EXPENSES-------*/

    // List all expenses
    public IEnumerable<Expenses> ListExpenses(){

        return _dbContext.Expenses.ToList();
    }

    // Add expense
    public Expenses AddExpense(Expenses expense)
    {   
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
            return expense;
    }

    // Delete expense

        public void DeleteExpense(Expenses expense)
    {
        _dbContext.Expenses.Add(expense);
        _dbContext.SaveChanges();
    }

    //Update expense


    /*--------INCOME-------*/


    /*--------INCOME TYPES-------*/


    /*--------EXPENSE TYPES-------*/




}