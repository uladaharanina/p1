public static class Validator
{
    public static bool ValidateName(string name){
        if(name == null || name.Length == 0 || name == ""){
            return false;
        }
        else{
           return true;

        }
    }

    public static bool ValidateType(string type){
        if(type == null || type.Length == 0 || type == ""){
            return false;
        }
        else{
           return true;

        }
    }

    public static bool ValidateAmount(double amount){
        if(amount < 0){
           return false;
        }
        else{
           return true;
        }
    }
    public static bool ValidateAll(string name, string type, double amount){

        if(ValidateName(name) && ValidateType(type) && ValidateAmount(amount)){
            return true;
        }
        else{
            return false;
        }
    }


}