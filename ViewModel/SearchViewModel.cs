using dws.models.Organization;
using dws.models.ProjectManagement;
using Maui.Plugins.PageResolver;
using MobileTime.Classes;
using MobileTime.Helper;
using MobileTime.Services.Interfaces;
using MobileTime.ViewHelper;
using System.ComponentModel;
using System.Windows.Input;

namespace MobileTime.ViewModel
{
    public class SearchViewModel : BindableObject, IDisposable
    {

        private ICustomerStore customerStore;
        private IProjectTaskStore projectTaskStore;
        private ILoggingStore loggingStore;
        public static event EventHandler<SearchModel> SearchViewModelSelectedEvent;
        
        public static event EventHandler<ProjectModel> SearchViewNewJobCreatedEvent;
        
        public static event EventHandler<string> AddNewJobClickEvent;

        public static CustomerModel SelectedCustomer { get; set; }
        public static ProjectModel SelectedProject { get; set; }
        public string InputText { get; set; }

        public ICommand OnShowSearchCommand { get; private set; }
        public ICommand OnAddNewCommand { get; private set; }

        
        public SearchViewModel()
        {
            customerStore = ServiceResolver. Resolve<ICustomerStore>();
            projectTaskStore = ServiceResolver.Resolve<IProjectTaskStore>();
            loggingStore = ServiceResolver.Resolve<ILoggingStore>();
            OnShowSearchCommand = new Command<string>(async (string arg) => await ShowSearchCommand(arg));
            OnAddNewCommand = new Command<string>(async (string arg) => await AddNewCommand(arg));            
        }

        private async Task ShowSearchCommand(string arg)
        {
            SearchListViewModel.ListSearchType = arg;
            SearchListViewModel.SearchViewModelSelected += async (source, e) =>
            {
                SearchViewModelSelectedEvent?.Invoke(this, e);
                InputText = e.Name;
                OnPropertyChanged("InputText");                        
            };            

            await Application.Current.MainPage.Navigation.PushAsync<SearchList>();
        }

        private async Task AddNewCommand(string arg)
        {
            switch (arg)
            {
                case "Job":
                    if (SelectedCustomer != null)
                    {
                        var model = ServiceResolver.Resolve<JobDetailViewModel>();
                        model.SetSelectedCustomer(SelectedCustomer);
                        var view = ServiceResolver.Resolve<JobDetailView>();
                        AddNewJobClickEvent?.Invoke(this, arg);

                        JobDetailViewModel.JobDetailCreatedNew += JobDetailCreatedNew;

                        await Application.Current.MainPage.Navigation.PushAsync(view);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Add Job", "A Customer selection is required!", "OK");
                    }
                    break;
                default:
                        await App.Current.MainPage.DisplayAlert("Add", "On job creation is supported", "OK");
                    break;
            
            }

        }

        public void JobDetailCreatedNew(object sender, ProjectModel e)
        {
            JobDetailViewModel.JobDetailCreatedNew -= JobDetailCreatedNew;
            SearchViewNewJobCreatedEvent?.Invoke(this, e);
            InputText = e.ShortDescription;
            OnPropertyChanged("InputText");            
        }


        public void Dispose()
        {
            if (SelectedCustomer != null)
                SelectedCustomer = null;
            if (SelectedProject != null)
                SelectedProject = null;
        }
    }
}
