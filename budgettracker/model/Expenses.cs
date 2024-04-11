

//Define a model for expenses
class Expenses
{
    public int ExpenseId { get; private set; } // ID
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }    
}