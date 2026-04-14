using FluentValidation.Results;

namespace Meetzy.Application.Exceptions
{
    [Serializable]
    internal class CustomValidationException : Exception
    {
        public ValidationResult Errors { get; }

        public CustomValidationException(ValidationResult result)
        {
            Errors = result;
        }

        public CustomValidationException()
        {
        }


        public CustomValidationException(string? message) : base(message)
        {
        }

        public CustomValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}