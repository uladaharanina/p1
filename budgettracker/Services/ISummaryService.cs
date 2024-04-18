namespace budgettracker;
public interface ISummaryService{

    public Dictionary<String, String> GetSummary();

    public Dictionary<String, String> GetExpensesCategories();
    public Dictionary<String, String> GetIncomeCategories();

}

