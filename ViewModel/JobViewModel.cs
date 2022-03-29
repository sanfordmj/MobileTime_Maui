using Maui.Plugins.PageResolver;
using MobileTime.Classes;
using MobileTime.Services;
using MobileTime.Services.Interfaces;
using dws.models.ProjectManagement;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.XamarinForms.Common;
using dws.models.Organization;
using MobileTime.Helper;

namespace MobileTime.ViewModel
{
    public class JobViewModel :  BaseViewModel
    {

        private IPageService _pageService;
        private IProjectStore _projectStore;
        private ICustomerStore _customerStore;

        public SearchModel SelectedCustomerSearch { get; set; }
        public SearchModel SelectedJobSearch { get; set; }

        private bool _IsDetailLoading;
        public bool IsDetailLoading { get { return _IsDetailLoading; } set { _IsDetailLoading = value; OnPropertyChanged("IsDetailLoading"); } }

        private ProjectModel selectedProject;
        public ProjectModel SelectedProject { get { return selectedProject; } set { selectedProject = value; OnPropertyChanged("SelectedProject"); } }
        public CustomerModel SelectedCustomer { get; set; }

        private DateTime jobStartDate;
        private DateTime jobStartTime;
        private DateTime jobEndDate;
        private DateTime jobEndTime;
        public DateTime JobStartDate { get => jobStartDate; set { jobStartDate = value; OnPropertyChanged("JobStartDate"); } }

        public DateTime JobStartTime { get => jobStartTime; set { jobStartTime = value; OnPropertyChanged("JobStartTime"); } }

        public DateTime JobEndDate { get => jobEndDate; set { jobEndDate = value; OnPropertyChanged("JobEndDate"); } }

        public DateTime JobEndTime { get => jobEndTime; set { jobEndTime = value; OnPropertyChanged("JobEndTime"); } }
        public ICommand OnSearchClickCommand;
        public ICommand OnShowMaterialListViewCommand;
        public ICommand OnCancelCommand;

        public JobViewModel(IPageService pageService, ILoggingStore loggingStore, IProjectStore projectStore, ICustomerStore customerStore)
        {
            
            _pageService = pageService;
            _projectStore = projectStore;
            _customerStore = customerStore;
            OnSearchClickCommand = new Command<string>(async (string ListSearchType) => await SearchClickCommand(ListSearchType));
            OnShowMaterialListViewCommand = new Command(async () => await ShowMaterialListViewCommand());
            OnCancelCommand = new Command(async () => await CancelCommand());

            JobStartDate = DateTime.Now;
            JobStartTime = DateTime.Now;

            JobEndDate = DateTime.Now;
            JobEndTime = DateTime.Now.AddHours(6);

            OnPropertyChanged("JobStartDate");
            OnPropertyChanged("JobStartTime");

            SearchViewModel.AddNewJobClickEvent += (source, e) =>
            {
                var model = ServiceResolver.Resolve<SearchViewModel>();                
                SearchViewModel.SearchViewNewJobCreatedEvent += SearchViewNewJobCreatedEvent;
            };

            SearchViewModel.SearchViewModelSelectedEvent += async (source, e) =>
            {
                if (e.Type.Equals("Customer"))
                {
                    SelectedCustomerSearch = e;                    
                    await GetSelectedCustomer();
                }
                else
                {
                    SelectedJobSearch = e;
                    await GetSelectedProject();
                }
                await _pageService.PopAsync();
            };

            m_LoadingChanged += HandelLoading;
            
        }

        public async Task SearchClickCommand(string arg)
        {
            await Task.Delay(1000);

        }

        private async Task ShowMaterialListViewCommand()
        {
            if (SelectedProject == null)
            {
                await _pageService.DisplayAlert("Job", "A Selected Job is Required for this action", "OK");
            }
            else
            {
                var model = ServiceResolver.Resolve<MaterialListViewModel>();
                await model.SetSelectedProject(SelectedProject);
                var view = ServiceResolver.Resolve<MaterialListView>();                
                await Application.Current.MainPage.Navigation.PushAsync(view);
            }
        }

        private async Task GetSelectedProject()
        {
            if (SelectedJobSearch == null)
                return;

            SelectedProject = await _projectStore.Get(SelectedJobSearch.Key);
            OnPropertyChanged(nameof(SelectedProject));
        }

        private async Task GetSelectedCustomer()
        {
            if (SelectedCustomerSearch == null)
                return;

            SelectedCustomer = await _customerStore.Get(SelectedCustomerSearch.Key);
            SearchViewModel.SelectedCustomer = SelectedCustomer;
            OnPropertyChanged(nameof(SelectedCustomer));
        }

        private void SearchViewNewJobCreatedEvent(object sender, ProjectModel e)
        {
            SelectedProject = e;
            OnPropertyChanged("SelectedProject");
            Application.Current.MainPage.Navigation.PopAsync();

            SearchViewModel.SearchViewNewJobCreatedEvent -= SearchViewNewJobCreatedEvent;
        }

        private async Task CancelCommand()
        {
            await _pageService.PopAsync();
        }

        private void HandelLoading(object sender, bool e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsDetailLoading = e;
                OnPropertyChanged("IsDetailLoading");
            });
        }

    }
}
