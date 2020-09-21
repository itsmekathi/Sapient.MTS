namespace Sapient.MTS.Common.Exceptions
{
    public class InvalidRequestException : BaseApplicationException
    {
        public InvalidRequestException(string message)
            : base(message)
        {
        }
    }
}
