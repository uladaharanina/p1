using budgettracker.data;
namespace budgettracker;

public class IncomeRepo : IRepository<Income>
{
    
 private readonly BudgetContext _dbContext;

 public IncomeRepo(BudgetContext context){
    this._dbContext = context;
 }

   // List all income
    public IEnumerable<Income> List(){

        return _dbContext.Income.ToList();
    }

    // Add expense
    public Income Add(Income income)
    {   
            _dbContext.Income.Add(income);
            _dbContext.SaveChanges();
            return income;
    }

    // Delete expense

        public void Delete(Income income)
    {
            _dbContext.Income.Remove(income);
            _dbContext.SaveChanges();
    }

    //Update expense

        public void Update(Income income)
    {   
        
        _dbContext.Income.Update(income);
        _dbContext.SaveChanges();
    }

    //Get expense by id
    public Income GetById(int id)
    {
        return _dbContext.Income.Find(id);
    }

}