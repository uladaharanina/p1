using System.Text.RegularExpressions;

public static class Validator
{
    public static bool ValidateName(string name){
        if(Regex.IsMatch(name, @"[!@#$%^&*]")){
            return false;
        }
        else{
           return true;

        }
    }

    public static bool ValidateType(string type){
        if(Regex.IsMatch(type, @"[!@#$%^&*]")){
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