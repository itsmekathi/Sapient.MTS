namespace Sapient.MTS.Common.Exceptions
{
    public class ValidationException : BaseApplicationException
    {
        public ValidationException(string message)
            : base( !string.IsNullOrEmpty(message) ? message: "One or more validation failures have occurred.")
        {
        }
    }
}
