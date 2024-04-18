using System.ComponentModel.DataAnnotations;

public class Income
{   
    [Key]
    public int IncomeId { get; set; } // ID
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }= null!;

    [Required(ErrorMessage = "Type is required")]

    public string Type { get; set; }= null!;
    [Required(ErrorMessage = "Amount is required")]
    public double Amount { get; set; }

    public DateTime Date { get; set; }
}