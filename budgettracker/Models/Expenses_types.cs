using System.ComponentModel.DataAnnotations;

public class Expenses_types
{   
    [Key]
    public int ExpensesId { get; set; } // ID
    public String expenseName { get; set; } = null!;
}