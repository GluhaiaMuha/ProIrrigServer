namespace ProIrrigServer.Services.IService;

public interface IFirebaseAuthService
{
    Task<string> SignUp(string email, string password);
    Task SignOut(string uid);
}