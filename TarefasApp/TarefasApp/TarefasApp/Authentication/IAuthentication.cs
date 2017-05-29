using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace TarefasApp.Authentication
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null);
    }
}