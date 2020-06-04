using System;
using System.Threading.Tasks;
using DeliveryAPI.Contracts;
using DeliveryAPI.Contracts.V1.Requests;
using DeliveryAPI.Contracts.V1.Responses;
using DeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }


            return Ok(new AuthSucessResponse {
                Token = authResponse.Token
            });
        }
    }
}
