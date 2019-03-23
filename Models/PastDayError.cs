using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models
{
    class PastDayError : Exception
    {
        private string _message;
        private DateTime? _birth;

        public PastDayError(string message, DateTime birth)
        {
            _message = message;
            _birth = birth;
        }

        public PastDayError(string message)
        {
            _message = message;
        }

        public PastDayError(DateTime birth) : this("The date of birth is incorrect", birth)
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
