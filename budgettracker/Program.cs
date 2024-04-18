using budgettracker;
using budgettracker.data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = builder.Configuration["dbconnectionstring"];

builder.Services.AddDbContext<BudgetContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();

// Add budget repository and service
builder.Services.AddScoped<IRepository<Expenses>,ExpenseRepo>();
builder.Services.AddScoped<IRepository<Income>,IncomeRepo>();


builder.Services.AddScoped<ExpensesService>();
builder.Services.AddScoped<IncomeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
