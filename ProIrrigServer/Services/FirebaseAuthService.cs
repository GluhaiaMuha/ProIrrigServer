using FirebaseAdmin.Auth;
using ProIrrigServer.Services.IService;

namespace ProIrrigServer.Services;

public class FirebaseAuthService : IFirebaseAuthService
{
    private readonly FirebaseAuth _firebaseAuth;

    public FirebaseAuthService(FirebaseAuth firebaseAuth)
    {
        _firebaseAuth = firebaseAuth;
    }

    public async Task<string> SignUp(string email, string password)
    {
        var userArgs = new UserRecordArgs()
        {
            Email = email,
            EmailVerified = false,
            Password = password,
            Disabled = false,
        };

        try
        {
            var userRecord = await _firebaseAuth.CreateUserAsync(userArgs);
            return userRecord.Uid;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task SignOut(string uid)
    {
        await _firebaseAuth.RevokeRefreshTokensAsync(uid);
    }
    
}