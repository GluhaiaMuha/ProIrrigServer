using Microsoft.AspNetCore.Mvc;
using ProIrrigServer.Models;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;

namespace ProIrrigServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<SensorDataModel>> GetSensorData(string idToken)
        {
            try
            {
                var isTokenValid = await VerifyToken(idToken);
                if (!isTokenValid)
                {
                    return Unauthorized();
                }

                return new SensorDataModel
                {
                    Temperature = "25",
                    Humidity = "50",
                    SoilMoisture = "30"
                };
            }
            catch (System.FormatException e)
            {
                return BadRequest(e.Message);
                throw;
            }
            
        }

        private async Task<bool> VerifyToken(string idToken)
        {
            try
            {
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                // Token is valid, you can use the uid of the user
                var uid = decodedToken.Uid;
                return true;
            }
            catch (FirebaseAuthException)
            {
                return false;
            }
        }
    }
}