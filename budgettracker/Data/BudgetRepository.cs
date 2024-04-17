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

    /*--------EXPENSES-------------
    -----------------------------*/

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
            _dbContext.Expenses.Remove(expense);
            _dbContext.SaveChanges();
    }

    //Update expense

        public void UpdateExpense(Expenses expense)
    {   
        
        _dbContext.Expenses.Update(expense);
        _dbContext.SaveChanges();
    }

    //Get expense by id
    public Expenses GetExpenseById(Expenses expense)
    {
        return _dbContext.Expenses.Find(expense.ExpenseId);
    }


    /*--------INCOME----------------------
    -----------------------------------*/

   // List all income
    public IEnumerable<Income> ListIncome(){

        return _dbContext.Income.ToList();
    }

    // Add expense
    public Income AddIncome(Income income)
    {   
            _dbContext.Income.Add(income);
            _dbContext.SaveChanges();
            return income;
    }

    // Delete expense

        public void DeleteIncome(Income income)
    {
            _dbContext.Income.Remove(income);
            _dbContext.SaveChanges();
    }

    //Update expense

        public void UpdateIncome(Income income)
    {   
        
        _dbContext.Income.Update(income);
        _dbContext.SaveChanges();
    }

    //Get expense by id
    public Income GetIncomeById(Income income)
    {
        return _dbContext.Income.Find(income.IncomeId);
    }



}