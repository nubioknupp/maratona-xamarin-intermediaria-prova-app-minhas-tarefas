using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using TarefasApp.Authentication;
using TarefasApp.Helpers;
using TarefasApp.iOS.Authentication;
using Xamarin.Forms;
using UIKit;

[assembly: Dependency(typeof(SocialAuthentication))]
namespace TarefasApp.iOS.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, 
            MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var current = GetController();
                var user = await client.LoginAsync(current, provider);

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

        private static UIViewController GetController()
        {
            var windows = UIApplication.SharedApplication.KeyWindow;
            var root = windows.RootViewController;

            if (root == null) return null;

            var current = root;

            while (current.PresentedViewController != null) current = current.PresentedViewController;

            return current;
        }
    }
}