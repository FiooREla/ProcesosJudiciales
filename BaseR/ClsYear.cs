using System;

public class ClsYear
{
    public static string FnEdad(DateTime? fNacimiento)
    {
        if (fNacimiento == null) return "";
        var today = DateTime.Today;
        var age = today.Year - fNacimiento.Value.Year;
        if (fNacimiento > today.AddYears(-age)) age--;
        return age.ToString();
    }
}