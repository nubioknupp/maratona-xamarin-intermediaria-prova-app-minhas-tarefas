using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TarefasApp.Services;
using Xamarin.Forms;

namespace TarefasApp.ViewModels.Bases
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public async Task PushAsync<TViewModel>(string folder, params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewTypeName = $"TarefasApp.Views.{folder}.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
            var viewType = Type.GetType(viewTypeName);

            var page = Activator.CreateInstance(viewType) as Page;

            if (viewModelType.GetTypeInfo().DeclaredConstructors
                .Any(c => c.GetParameters().Any(p => p.ParameterType == typeof(ITarefasAppService))))
            {
                var argsList = args.ToList();
                var service = DependencyService.Get<ITarefasAppService>();
                argsList.Insert(0, service);
                args = argsList.ToArray();
            }

            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null)
                page.BindingContext = viewModel;

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

		public virtual Task LoadAsync()
		{
			return Task.FromResult(0);
		}

    }
}