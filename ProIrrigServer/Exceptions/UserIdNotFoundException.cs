namespace ProIrrigServer.Exceptions;

public class UserIdNotFoundException : Exception
{
    public UserIdNotFoundException(int id, Exception? innerException) : base($"User with Id {id} was not found", innerException)
    {
    }
}