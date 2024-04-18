using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Income
{
    public Income(string name, string type, double amount)
    {
        Name = name;
        Type = type;
        Amount = amount;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int IncomeId { get; set;} // ID
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }= null!;

    [Required(ErrorMessage = "Type is required")]

    public string Type { get; set; }= null!;
    [Required(ErrorMessage = "Amount is required")]
    public double Amount { get; set; }

    public DateTime Date { get; set; }
}