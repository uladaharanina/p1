namespace budgettracker;

public class IncomeService : IBudgetService<Income>
{   
    private readonly IRepository<Income> _IncomeRepository;

    public IncomeService (IRepository<Income> _IncomeRepository){
        this._IncomeRepository = _IncomeRepository;
    }

    public IEnumerable<Income> ListItems() {
        return _IncomeRepository.List();
    }

    public Income AddItem(Income data){
      
      if(Validator.ValidateAll(data.Name, data.Type, data.Amount)){
        return _IncomeRepository.Add(data);
      }
      else{
        return null;
      }

    }
    public bool DeleteItem(Income data){
        //Find id of the expense
        Income incomeToDelete = _IncomeRepository.GetById(data.IncomeId);
        if(incomeToDelete != null){
            _IncomeRepository.Delete(incomeToDelete);
            return true;
        }
        else{
            return false;
        }
    }

    public Income UpdateItem(Income data){

        Income IncomeToUpdate = _IncomeRepository.GetById(data.IncomeId);
        if(IncomeToUpdate != null){
            
            if(Validator.ValidateAll(data.Name, data.Type, data.Amount)){
                IncomeToUpdate.Amount = data.Amount;
                IncomeToUpdate.Name = data.Name;
                IncomeToUpdate.Type = data.Type;

                _IncomeRepository.Update(IncomeToUpdate);
                return IncomeToUpdate;
            }
            else{
                return null;
            }

        }
        else{
            return null;
        }
    }

    public Income GetItemById(int id){
        return _IncomeRepository.GetById(id);
    }
}
