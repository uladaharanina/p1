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


    [Theory]
    [InlineData("Walmart", "Groceries", 150.00, "Walmart")]
    [InlineData("", "Groceries", 150.00, null)]
    [InlineData("Walmart", "", 150.00, null)]
    [InlineData("Walmart", "Groceries", -150.00, null)]
    //Add new expense
    public void AddExpenseTest(string name, string type, double amount, string expectedName){
        //Arrange
        Mock <IRepository<Expenses>> repo = new Mock<IRepository<Expenses>>();
         //Create fake data 
        Expenses newExpense = new Expenses{
                Name = name,
                Type = type,
                Amount = amount,
                Date = DateTime.Now
        };

        repo.Setup(repo => repo.Add(newExpense)).Returns(newExpense);
        ExpensesService service = new ExpensesService(repo.Object);

        //Act
        Expenses addnewExpense = service.AddItem(newExpense);

        if(string.IsNullOrEmpty(expectedName)){
            Assert.Null(addnewExpense);
        }
        else{
            Assert.Equal(expectedName, addnewExpense.Name);
            repo.Verify(repo => repo.Add(newExpense), Times.Exactly(1));
        }
        
    }

    //Add new income

    [Theory]
    [InlineData("Building a house", "Side gig", 15000.00, "Building a house")]
    [InlineData("", "Side gig", 15000.00, null)]
    [InlineData("Building a house", "", 15000.00, null)]
    [InlineData("Building a house", "Side gig", -15000.00, null)]
    public void AddIncomeTest(string name, string type, double amount, string expectedName){
        //Arrange
        Mock <IRepository<Income>> repo = new Mock<IRepository<Income>>();
         //Create fake data 
        Income newIncome = new Income{
                Name = name,
                Type = type,
                Amount = amount,
                Date = DateTime.Now
        };

        repo.Setup(repo => repo.Add(newIncome)).Returns(newIncome);
        IncomeService service = new IncomeService(repo.Object);

        //Act
        Income addnewIncome = service.AddItem(newIncome);

        if(string.IsNullOrEmpty(expectedName)){
            Assert.Null(addnewIncome);
        }
        else{
            Assert.Equal(expectedName, addnewIncome.Name);
            repo.Verify(repo => repo.Add(newIncome), Times.Exactly(1));
        }
        
    }
    
    
    //Edit expense
    [Theory]
    [InlineData(1, "Walmart", "Groceries", 150.00, "Walmart")]
    [InlineData(null,"", "Groceries", 150.00, null)]
    [InlineData(1,"Walmart", "", 150.00, null)]
    [InlineData(1, "Walmart", "Groceries", -150.00, null)]
    [InlineData(10, "Walmart", "Groceries", 150.00, null)]

    public void EditExpenseTest(int id, string name, string type, double amount, string expectedName){
        //Arrange
        Mock <IRepository<Expenses>> repo = new Mock<IRepository<Expenses>>();
         //Create fake data 
        Expenses currentExpense = new Expenses{
                ExpenseId = 1,
                Name = "My Expenses",
                Type = "None",
                Amount = 45.00,
                Date = DateTime.Now
        };

        repo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns<int>(id => id == currentExpense.ExpenseId ? currentExpense : null);
        ExpensesService service = new ExpensesService(repo.Object);

        Expenses ExpenseToUpdate = new Expenses{
                ExpenseId = id,
                Name = name,
                Type = type,
                Amount = amount
        };

        //Act
        Expenses updateExpense = service.UpdateItem(ExpenseToUpdate);

        if(string.IsNullOrEmpty(expectedName)){
            Assert.Null(updateExpense);
        }
        else{
            Assert.Equal(expectedName, updateExpense.Name);
            repo.Verify(repo => repo.Update(It.IsAny<Expenses>()), Times.Exactly(1));
        }
        
    }
    //Edit income
    [Theory]
    [InlineData(1, "Google", "Stocks", 150.00, "Google")]
    [InlineData(null,"", "Stocks", 150.00, null)]
    [InlineData(1,"Google", "", 150.00, null)]
    [InlineData(1, "Google", "Stocks", -150.00, null)]
    [InlineData(10, "Google", "Stocks", 150.00, null)]
    public void EditIncomeTest(int id, string name, string type, double amount, string expectedName){
          //Arrange
        Mock <IRepository<Income>> repo = new Mock<IRepository<Income>>();
         //Create fake data 
        Income currentIncome = new Income{
                IncomeId = 1,
                Name = "My Income",
                Type = "None",
                Amount = 405.00,
                Date = DateTime.Now
        };

        repo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns<int>(id => id == currentIncome.IncomeId ? currentIncome : null);
        IncomeService service = new IncomeService(repo.Object);

        Income IncomeToUpdate = new Income{
                IncomeId = id,
                Name = name,
                Type = type,
                Amount = amount
        };

        //Act
        Income updateIncome = service.UpdateItem(IncomeToUpdate);

        if(string.IsNullOrEmpty(expectedName)){
            Assert.Null(updateIncome);
        }
        else{
            Assert.Equal(expectedName, updateIncome.Name);
            repo.Verify(repo => repo.Update(It.IsAny<Income>()), Times.Exactly(1));
        }
    }

    //Delete expense
    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    public void TestDeleteExpense(int id, bool expectedResult){

        Mock <IRepository<Expenses>> repo = new Mock<IRepository<Expenses>>();

        Expenses currentExpense = new Expenses{
                ExpenseId = 1,
                Name = "My Expenses",
                Type = "None",
                Amount = 45.00,
                Date = DateTime.Now
        };

        Expenses ExpensetoDelete = new Expenses{
                ExpenseId = id,
                Name = "My Expenses",
                Type = "None",
                Amount = 45.00,
                Date = DateTime.Now
        };

        repo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns<int>(id => id == currentExpense.ExpenseId ? currentExpense : null);
        ExpensesService service = new ExpensesService(repo.Object);

        //Act
        bool result = service.DeleteItem(ExpensetoDelete);
        Assert.Equal(expectedResult, result);
        repo.Verify(repo => repo.Delete(It.IsAny<Expenses>()), expectedResult ? Times.Once() : Times.Never());

    }

    //Delete income
    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    public void TestDeleteIncome(int id, bool expectedResult){

        Mock <IRepository<Income>> repo = new Mock<IRepository<Income>>();

        Income currentIncome = new Income{
                IncomeId = 1,
                Name = "My Income",
                Type = "None",
                Amount = 45.00,
                Date = DateTime.Now
        };

        Income IncometoDelete = new Income{
                IncomeId = id,
                Name = "My Expenses",
                Type = "None",
                Amount = 45.00,
                Date = DateTime.Now
        };

        repo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns<int>(id => id == currentIncome.IncomeId ? currentIncome : null);
        IncomeService service = new IncomeService(repo.Object);

        //Act
        bool result = service.DeleteItem(IncometoDelete);
        Assert.Equal(expectedResult, result);
        repo.Verify(repo => repo.Delete(It.IsAny<Income>()), expectedResult ? Times.Once() : Times.Never());

    }
    //Display Summary

    [Fact]
    public void TestSummaryInformation(){

        Mock <IRepository<Expenses>> ExpenseRepo = new Mock<IRepository<Expenses>>();
        Mock <IRepository<Income>> IncomeRepo = new Mock<IRepository<Income>>();

        Expenses currentExpense = new Expenses{
                ExpenseId = 1,
                Name = "Car Payment",
                Type = "Loan",
                Amount = 145.00,
                Date = DateTime.Now
        };

        Income currentIncome = new Income{
                IncomeId = 1,
                Name = "Google",
                Type = "Salary",
                Amount = 1045.00,
                Date = DateTime.Now
        };

        ExpenseRepo.Setup(repo => repo.List()).Returns(new List<Expenses> {currentExpense});
        IncomeRepo.Setup(repo => repo.List()).Returns(new List<Income> {currentIncome});

        SummaryService service = new SummaryService(ExpenseRepo.Object, IncomeRepo.Object);

        Dictionary<string,string> result = service.GetSummary();
        string expectedTotal = "900";
        Assert.Equal(expectedTotal, result["Profit"]);
    }


    //Test types
    [Fact]
    public void TestGetExpensesCategories(){

        Mock <IRepository<Expenses>> ExpenseRepo = new Mock<IRepository<Expenses>>();
        Mock <IRepository<Income>> IncomeRepo = new Mock<IRepository<Income>>();


          IEnumerable<Expenses>  currentExpense = [
            
            new Expenses {
                ExpenseId = 1,
                Name = "Car Payment",
                Type = "Loan",
                Amount = 145.00,
                Date = DateTime.Now
                },

            new Expenses  {
                ExpenseId = 2,
                Name = "House Payment",
                Type = "Loan",
                Amount = 1450.00,
                Date = DateTime.Now
                }
        ];
               

        ExpenseRepo.Setup(repo => repo.List()).Returns(currentExpense);

        SummaryService service = new SummaryService(ExpenseRepo.Object, IncomeRepo.Object);

        Dictionary<string, string> result = service.GetExpensesCategories();
        string expectedSum = "1595";
        Assert.Equal(expectedSum, result["Loan"]);

    }



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

    public void TestAllInput(string name, string type, double amount, bool expectedResult){

        Assert.Equal(expectedResult, Validator.ValidateAll(name, type, amount));
        Assert.Equal(expectedResult, Validator.ValidateAll(name, type, amount));
        Assert.Equal(expectedResult, Validator.ValidateAll(name, type, amount));
        Assert.Equal(expectedResult, Validator.ValidateAll(name, type, amount));
        Assert.Equal(expectedResult, Validator.ValidateAll(name, type, amount));


    }
}