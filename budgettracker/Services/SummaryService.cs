
namespace budgettracker;
public class SummaryService : ISummaryService{

   private readonly IRepository<Expenses> _ExpensesRepository;
        private readonly IRepository<Income> _IncomeRepository;

        public SummaryService(IRepository<Expenses> expensesRepository, IRepository<Income> incomeRepository)
        {
            _ExpensesRepository = expensesRepository;
            _IncomeRepository = incomeRepository;
        }

        public Dictionary<String, String> GetSummary()
        {   
            IEnumerable<Expenses> myExpenses = _ExpensesRepository.List();
            IEnumerable<Income> myIncome = _IncomeRepository.List();

            Dictionary<String, String> summary = new Dictionary<String, String>();

            double totalIncome = myIncome.Sum(income => income.Amount);
            double HighestEarnings = myIncome.Max(income => income.Amount);
            double totalExpense = myExpenses.Sum(expense => expense.Amount);
            double profit = totalIncome - totalExpense;
            double HighestSpending = myExpenses.Max(expense => expense.Amount);

            summary.Add("Total Income", totalIncome.ToString());
            summary.Add("Highest Earnings", HighestEarnings.ToString());
            summary.Add("Total Expenses", myExpenses.Sum(expense => expense.Amount).ToString());
            summary.Add("Highest Spending",HighestSpending.ToString());
            summary.Add("Profit", profit.ToString());

            return summary;

        }

    public Dictionary<String, String> GetExpensesCategories(){

            IEnumerable<Expenses> myExpenses = _ExpensesRepository.List();
            Dictionary<String, String> types = new Dictionary<String, String>();

            var expenseTypes = myExpenses.GroupBy(expense => expense.Type)
            .Select(types => new {Type = types.Key, Amount = types.Sum(expense => expense.Amount)})
            .ToList();

            foreach (var type in expenseTypes){
                types.Add(type.Type, type.Amount.ToString());
            }

            return types;

    }
    public Dictionary<String, String> GetIncomeCategories(){

            IEnumerable<Income> myIncome = _IncomeRepository.List();
            Dictionary<String, String> types = new Dictionary<String, String>();

            var icnomeTypes = myIncome.GroupBy(income => income.Type)
            .Select(types => new {Category = types.Key, Amount = types.Sum(income => income.Amount)})
            .ToList();
            
            foreach (var type in icnomeTypes){
                types.Add(type.Category, type.Amount.ToString());
            }

            return types;

        }  
    }
    

    
        