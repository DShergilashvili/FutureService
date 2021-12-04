namespace FutureService.Api.Errors.Exceptions
{
    public class UserExistsException: ServiceException
    {
        public override int HttpStatusCode => StatusCodes.Status409Conflict;
        public override string ErrorMessage => "User already exists.";
    }
}
