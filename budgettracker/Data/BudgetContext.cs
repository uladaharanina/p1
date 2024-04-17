using System;
using Microsoft.EntityFrameworkCore;
namespace budgettracker.data;

// responsible for manage DB interactions and table representations

public class BudgetContext : DbContext
{
    private readonly IConfiguration _configuration; // contains connection string

    public DbSet<Income> ? Income { get; set; }
    public DbSet<Expenses> ? Expenses { get; set; }


    public BudgetContext(DbContextOptions<BudgetContext> options, IConfiguration configuration) : base(options){
        _configuration = configuration; //set a connection string
    }


}
