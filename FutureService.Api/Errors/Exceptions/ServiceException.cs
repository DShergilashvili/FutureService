namespace FutureService.Api.Errors.Exceptions
{
    public abstract class ServiceException: Exception
    {
        public abstract int HttpStatusCode { get; }
        public abstract string ErrorMessage { get; }
    }
}
