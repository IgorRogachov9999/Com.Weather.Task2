namespace Com.Weather.Task2.Domain.Services.Exceptions
{
    public class InvalidPollingException : DomainException
    {
        public InvalidPollingException(string errorMessage) : base(errorMessage, null)
        {
        }

        public override int ErrorCode => 500;
    }
}
