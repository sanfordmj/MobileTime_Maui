using dws.models.Organization;
using dws.models.ProjectManagement;
using MobileTime.Classes;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTime.ViewModel
{
    public class JobDetailViewModel : BaseViewModel
    {

        private IPageService _pageService;
        private IProjectStore _projectStore;
        public static EventHandler<ProjectModel> JobDetailCreatedNew;

        public ICommand OnCancelCommand { get; private set; }
        public ICommand OnSaveCommand { get; private set; }

        public ProjectModel SelectedProject { get; set; }

        private CustomerModel selectedCustomer;
        public CustomerModel SelectedCustomer { get { return selectedCustomer; } set { selectedCustomer = value; OnPropertyChanged("SelectedCustomer"); } }

        private string jobDescription;
        public string JobDescription { get { return jobDescription; } set { jobDescription = value; OnPropertyChanged("JobDescription"); } }

        public JobDetailViewModel(IPageService pageService, ILoggingStore loggingStore, IProjectStore projectStore)
        {
            _pageService = pageService;
            _projectStore = projectStore;

            OnCancelCommand = new Command(async () => await CancelCommand());
            OnSaveCommand = new Command(async () => await SaveCommand());            
        }

        public void SetSelectedCustomer(CustomerModel value)
        {
            if (value == null)
                return;

            selectedCustomer = value;
            OnPropertyChanged("SelectedCustomer");
        }

        private async Task CancelCommand()
        {
            await _pageService.PopAsync();
        }

        private async Task SaveCommand()
        {
            SelectedProject = await SaveProject();
            if (SelectedProject.IX_Project > 0)
                JobDetailCreatedNew.Invoke(this, SelectedProject);
            else
                await _pageService.DisplayAlert("Save", "Job Save Event Failed!", "OK");
        }

        private async Task<ProjectModel> SaveProject()
        {
            return await _projectStore.Post(new ProjectModel { IX_Customer = SelectedCustomer.IX_Customer, ShortDescription = JobDescription });
        }

    }
}
