using ServiceContracts;


namespace Services.WebAPI.Helpers;

public static class ValidationHelpers
{
    public static List<string> Validate(EmployeeAddRequest request)
    {
        //empty list
        var errors = new List<string>();

        if(request == null)
        {
            errors.Add("Employee request Can't be Null.");
            return errors;
        }

        if (string.IsNullOrWhiteSpace(request.FirstName))
        {
            errors.Add("FirstName is Required");
        }

        if (string.IsNullOrWhiteSpace(request.LastName))
        {
            errors.Add("LastName is Required");
        }
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            errors.Add("Email is Required");
        }
        if (string.IsNullOrWhiteSpace(request.DateOfBirth.ToString()))
        {
            errors.Add("DateOfBirth is Required");
        }

        //return list<string> of Errors
        return errors;
    }
}
