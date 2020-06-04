using System;
using System.Threading.Tasks;
using DeliveryAPI.Domain;

namespace DeliveryAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);

    }
}
