namespace Meetzy.Domain.Exceptions
{
    public class BussinessRuleExceptions : Exception
    {
        public BussinessRuleExceptions(string message) : base(message) 
        {

        }

        public class BussinesRuleException : Exception
        {
            public BussinesRuleException()
            {
            }

            public BussinesRuleException(string? message) : base(message)
            {
            }

            public BussinesRuleException(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }
    }
}
