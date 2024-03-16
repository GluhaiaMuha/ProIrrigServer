using Microsoft.AspNetCore.Mvc;
using ProIrrigServer.Services;

namespace ProIrrigServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly FirebaseAuthService _firebaseAuthService;

    public AuthController(FirebaseAuthService firebaseAuthService)
    {
        _firebaseAuthService = firebaseAuthService;
    }
    
    [HttpPost("signup")]
    public Task<string> RegisterUser(string email, string password)
    {
        return _firebaseAuthService.SignUp(email, password);
    }

}