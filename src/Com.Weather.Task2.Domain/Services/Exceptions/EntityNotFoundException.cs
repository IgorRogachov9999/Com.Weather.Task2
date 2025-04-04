namespace Com.Weather.Task2.Domain.Services.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string errorMessage) : base(errorMessage, null)
        {
        }

        public override int ErrorCode => 404;
    }
}
