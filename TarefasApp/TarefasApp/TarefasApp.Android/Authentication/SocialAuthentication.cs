using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using TarefasApp.Authentication;
using TarefasApp.Helpers;
using TarefasApp.Droid.Authentication;
using Xamarin.Forms;

[assembly: Dependency(typeof(SocialAuthentication))]
namespace TarefasApp.Droid.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {

                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}