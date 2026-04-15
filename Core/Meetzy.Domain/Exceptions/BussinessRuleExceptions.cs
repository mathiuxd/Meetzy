namespace Meetzy.Domain.Exceptions
{
    public class BussinessRuleExceptions : Exception
    {
        public BussinessRuleExceptions(string message) : base(message)
        {
        }

        public BussinessRuleExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
