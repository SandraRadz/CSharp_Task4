using System;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models
{
    class NameError: Exception
    {
    private string _message;


    public NameError(string message)
    {
        _message = message;
    }


    public override string Message
    {
        get
        {
            return _message;
        }
    }
    }
}
