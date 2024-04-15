using System.ComponentModel.DataAnnotations;

public class Income_types
{   
    [Key]
    public int IncomeId { get; set; } // ID
    public string incomeName { get; set; }= null!;
}