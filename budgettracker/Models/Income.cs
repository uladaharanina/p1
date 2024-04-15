using System.ComponentModel.DataAnnotations;

public class Income
{   
    [Key]
    public int IncomeId { get; private set; } // ID
    public string Name { get; set; }= null!;
    public string Type { get; set; }= null!;
    public double Amount { get; set; }
    public DateTime Date { get; set; }    
}