using Meetzy.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Meetzy.Application.Exceptions
{
    public class MediatorException : Exception 
    {
        public MediatorException(string message) : base(message) 
        { 

        }
    }
}
