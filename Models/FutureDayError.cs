using System;
namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models
{
    class FutureDayError : Exception
    {
        private string _message;
        private DateTime? _birth;

        public FutureDayError(string message, DateTime birth)
        {
            _message = message;
            _birth = birth;
        }

        public FutureDayError(string message)
        {
            _message = message;
        }

        public FutureDayError(DateTime birth) : this("The date of birth is incorrect", birth)
        {
        }

        public override string Message
        {
            get
            {
                if (_birth != null)
                {
                    return _message + " " + _birth;
                }
                return _message;
            }
        }
    }
}
