using System;
namespace DeliveryAPI.Contracts.V1.Responses
{
    public class AuthSucessResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
