using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Define a model for expenses
public class Expenses
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExpenseId { get;  set; } // ID
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public double Amount { get; set; }
    public DateTime Date { get; set; }    
}