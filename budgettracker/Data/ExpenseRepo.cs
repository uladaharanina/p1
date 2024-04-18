using budgettracker.data;

namespace budgettracker;

public class ExpenseRepo : IRepository<Expenses>
{
    
 private readonly BudgetContext _dbContext;

 public ExpenseRepo(BudgetContext context){
    this._dbContext = context;
 }

   // List all expenses
    public IEnumerable<Expenses> List(){

        return _dbContext.Expenses.ToList();
    }

    // Add expense
    public Expenses Add(Expenses expense)
    {   
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
            return expense;
    }

    // Delete expense

        public void Delete(Expenses expense)
    {
            _dbContext.Expenses.Remove(expense);
            _dbContext.SaveChanges();
    }

    //Update expense

        public void Update(Expenses expense)
    {   
        _dbContext.Expenses.Update(expense);
        _dbContext.SaveChanges();
    }

    //Get expense by id
    public Expenses GetById(int id)
    {
        return _dbContext.Expenses.Find(id);
    }

}