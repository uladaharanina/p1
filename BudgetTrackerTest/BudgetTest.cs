namespace BudgetTrackerTest;
using budgettracker;
using Moq;

public class UnitTest1
{   

    //Test summary information
    [Fact]
    public void GetAllExpensesTest()
    {
        //Arrange
        Mock <IRepository<Expenses>> Repo = new Mock<IRepository<Expenses>>();

        //Create fake data 
        IEnumerable<Expenses> MockExpenses = [
            new Expenses
            {
                ExpenseId = 1,
                Name = "WholeFoods",
                Type = "Groceries",
                Amount = 100.50,
                Date = DateTime.Now
            },
            new Expenses
            {
                ExpenseId = 1,
                Name = "Gas Bill",
                Type = "Utilities",
                Amount = 90.50,
                Date = DateTime.Now
            }
        ];

        Repo.Setup(Repo => Repo.List()).Returns(MockExpenses);
        ExpensesService service = new ExpensesService(Repo.Object);

        //Act
        IEnumerable<Expenses> expenses = service.ListItems();

        //Assert

        Assert.Equal(2, expenses.Count());
        Repo.Verify(Repo => Repo.List(), Times.Exactly(1));
    }


    [Fact]
    public void GetAllIncomeTest(){

        Mock <IRepository<Income>> repo = new Mock<IRepository<Income>>();
        //Create fake data 
        IEnumerable<Income> MockExpenses = [
            new Income
            {
                IncomeId = 1,
                Name = "Apple",
                Type = "Stocks",
                Amount = 1050.50,
                Date = DateTime.Now
            },
            new Income
            {
                IncomeId = 2,
                Name = "Google",
                Type = "Stock",
                Amount = 1490.50,
                Date = DateTime.Now
            },
            new Income
            {
                IncomeId = 3,
                Name = "Nvidia",
                Type = "Stock",
                Amount = 149760.50,
                Date = DateTime.Now
            }
        ];

        repo.Setup(repo => repo.List()).Returns(MockExpenses);
        IncomeService service = new IncomeService(repo.Object);

        //Act
        IEnumerable<Income> income = service.ListItems();

        //Assert

        Assert.Equal(3, income.Count());
        repo.Verify(repo => repo.List(), Times.Exactly(1));
    }

    //Test summary information
    [Theory]
    [InlineData(50, true)]
    [InlineData(-50, false)] 
    //Test Amount 
    public void TestAmountInput(double amount, bool expectedResult){

        Assert.Equal(expectedResult, Validator.ValidateAmount(amount));
        Assert.Equal(expectedResult, Validator.ValidateAmount(amount));

    }
    //Test Name Input 

    [Theory]
    [InlineData("Whole Foods", true)]
    [InlineData("%^NoName", false)] 

    public void TestNameInput(string name, bool expectedResult){

        Assert.Equal(expectedResult, Validator.ValidateName(name));
        Assert.Equal(expectedResult, Validator.ValidateName(name));

    }

    //Test Type Input 
    [Theory]
    [InlineData("Groceries", true)]
    [InlineData("%^NoName", false)] 

    public void TestTypeInput(string type, bool expectedResult){

        Assert.Equal(expectedResult, Validator.ValidateType(type));
        Assert.Equal(expectedResult, Validator.ValidateType(type));

    }

    //Test All Input 
    [Theory]
    [InlineData("Groceries", "Food", 567.00, true)]
    [InlineData("%^NoName", "%^NoName", -567.00, false)]
    [InlineData("%^NoName", "Food", 567.00, false)]
    [InlineData("Groceries", "%^NoName", 567.00, false)]
    [InlineData("Groceries", "Food", -567.00, false)] 

    public void TestTypeInput(string name, bool expectedResult){

        Assert.Equal(expectedResult, Validator.ValidateAll(type));
        Assert.Equal(expectedResult, Validator.ValidateType(type));

    }
}