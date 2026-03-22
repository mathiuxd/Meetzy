using System;
using System.Collections.Generic;
using System.Text;

namespace Meetzy.Domain.Exceptions
{
    public class BussinessRuleExceptions : Exception
    {
        public BussinessRuleExceptions(string message) : base(message) 
        {

        }
    }
}
