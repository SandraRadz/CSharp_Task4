﻿using System;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models
{
    class EmailError : Exception
    {
        private string _message;


        public EmailError(string message)
        {
            _message = message;
        }


        public override string Message
        {
            get
            {
                return _message + ". Email must be like aaa@aa.aa";
            }
        }
    }
}
