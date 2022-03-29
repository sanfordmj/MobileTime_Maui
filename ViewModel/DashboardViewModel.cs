using Maui.Plugins.PageResolver;
using MobileTime.Classes;
using MobileTime.Services.Interfaces;
using MobileTime.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTime.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        IPageService _pageService = null;
        ILoggingStore _loggingStore = null;


        public ICommand OnJobCommand { get; private set; }

        public DashboardViewModel(IPageService pageService, ILoggingStore loggingStore)
        {
            _pageService = pageService;
            _loggingStore = loggingStore;

            OnJobCommand = new Command(async () => await JobCommand());
            
        }

        private async Task JobCommand()
        {
            SetIsLoading(true);
            await Task.Delay(200);
            await Application.Current.MainPage.Navigation.PushAsync<JobView>();            
        }
    }
}
