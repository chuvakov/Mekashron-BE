using Mekashron.Controllers.AuthorizationDto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Mekashron.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly MekashronService.ICUTechClient _client;
        public AuthorizationController(MekashronService.ICUTechClient client)
        {
            _client = client;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginInput loginInput)
        {
            MekashronService.LoginResponse result = await _client.LoginAsync(loginInput.Username, loginInput.Password, "rrr");

            LoginInfo info = JsonSerializer.Deserialize<LoginInfo>(result.@return)!;

            return Ok(info);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterInput registerInput)
        {
            MekashronService.RegisterNewCustomerResponse result = await _client.RegisterNewCustomerAsync(
                registerInput.Email, registerInput.Password, registerInput.Firstname, registerInput.Lastname,
                registerInput.Mobile, registerInput.CountryId, registerInput.AId, registerInput.SingupIp);

            RegisterInfo registerInfo = JsonSerializer.Deserialize<RegisterInfo>(result.@return)!;

            return Ok(registerInfo);
        }
    }
}