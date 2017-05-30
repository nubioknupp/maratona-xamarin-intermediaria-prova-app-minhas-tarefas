using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Plugin.Connectivity;
using TarefasApp.Authentication;
using TarefasApp.Helpers;
using TarefasApp.Models;
using TarefasApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]

namespace TarefasApp.Services
{
    public class AzureService
    {
        private MobileServiceClient _client;
        private IMobileServiceSyncTable<Categoria> _categoriaTable;
        private IMobileServiceSyncTable<Tarefa> _tarefaTable;

        private async Task Initialize()
        {
            _client = new MobileServiceClient("https://tarefasapps.azurewebsites.net");

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                _client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }

            //InitialzeDatabase for path
            var path = "syncstore.db";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

            //setup our local sqlite store and intialize our table
            var store = new MobileServiceSQLiteStore(path);

            //Define table
            store.DefineTable<Categoria>();
            store.DefineTable<Tarefa>();

            //Initialize SyncContext
            await _client.SyncContext.InitializeAsync(store);

            //Get our sync table that will call out to azure
            _categoriaTable = _client.GetSyncTable<Categoria>();
            _tarefaTable = _client.GetSyncTable<Tarefa>();
        }

        public async Task<bool> LoginAsync()
        {
            await Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(_client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    const string message = "Nao conseguimos efetuar o login, tente novamente!";
                    await Application.Current.MainPage.DisplayAlert("Ops!", message, "Ok");
                });

                return false;
            }

            Settings.AuthToken = user.MobileServiceAuthenticationToken;
            Settings.UserId = user.UserId;

            return true;
        }

        //public async Task SyncCategoria()
        //{
        //    try
        //    {
        //        if (!CrossConnectivity.Current.IsConnected) return;

        //        await _categoriaTable.PullAsync("allCategoria", _categoriaTable.CreateQuery());

        //        await _client.SyncContext.PushAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Unable to sync coffees, that is alright as we have offline capabilities: " + ex);
        //    }

       // }

        //public async Task<IEnumerable<CupOfCoffee>> GetCoffees()
        //{
        //    //Initialize & Sync
        //    await Initialize();
        //    await SyncCoffee();

        //    return await coffeeTable.OrderBy(c => c.DateUtc).ToEnumerableAsync(); ;

        //}

        //public async Task<CupOfCoffee> AddCoffee(bool atHome)
        //{
        //    await Initialize();

        //    var coffee = new CupOfCoffee
        //    {
        //        DateUtc = DateTime.UtcNow,
        //        MadeAtHome = atHome,
        //        OS = Device.OS.ToString()
        //    };

        //    await coffeeTable.InsertAsync(coffee);

        //    await SyncCoffee();
        //    //return coffee
        //    return coffee;
        //}



    }
}