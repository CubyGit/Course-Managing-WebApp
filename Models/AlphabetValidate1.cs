using System.Text.RegularExpressions;
namespace Asp.netMVC.Models;
public static class ModelValidationService
{
    public static bool ValidateName(string name)
    {
        return Regex.IsMatch(name, "^[a-zA-Z]+$");
    }

    public static bool ValidateWtNum(string wtNum)
    {
        return Regex.IsMatch(wtNum, "^[0-9]+$");
    }

    public static bool ValidateModel(TestTable model, out Dictionary<string, string> validationErrors)
    {
        validationErrors = new Dictionary<string, string>();

        if (!ValidateName(model.Name))
        {
            validationErrors.Add("Name", "Name can only contain alphabetic characters.");
        }

        if (!ValidateWtNum(model.WtNum))
        {
            validationErrors.Add("WtNum", "WtNum can only contain numeric characters.");
        }

        return validationErrors.Count == 0;
    }
}

