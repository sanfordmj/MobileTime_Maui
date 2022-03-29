using dws.models.Logging;
using dws.models.ProjectManagement;
using MobileTime.Classes;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.XamarinForms.Common;

namespace MobileTime.ViewModel
{
    public class MaterialListViewModel: BaseViewModel
    {
        IPageService _pageService;
        IProjectTaskTimeStore _projectTaskTimeStore;
        private readonly ILoggingStore _logger;
        public ICommand OnCancelCommand;
        public ICommand OnRefreshCommand;

        private ProjectModel _selectedProject;
        private bool _IsNotEmptyData;

        public bool IsNotEmptyData { get { return _IsNotEmptyData; } set { _IsNotEmptyData = value; OnPropertyChanged("IsNotEmptyData"); } }


        public ObservableCollection<ProjectTaskTimeModel> MaterialListItems { get; private set; } = new ObservableCollection<ProjectTaskTimeModel>();
        public MaterialListViewModel(IPageService pageService, ILoggingStore loggingStore, IProjectTaskTimeStore projectTaskTimeStore)
        {
            _pageService = pageService;
            _logger = loggingStore;
            OnCancelCommand = new Command(async () => await CancelCommand());
            OnRefreshCommand = new Command(async () => await RefreshCommand());
            _projectTaskTimeStore = projectTaskTimeStore;
            
        }

        private void MaterialListViewModel_NativeControlLoaded(object sender, EventArgs e)
        {
            string a = "";
        }

        private async Task CancelCommand()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task LoadMaterialData()
        {
            try
            {
                var projectTaskTimes = await _projectTaskTimeStore.Get(_selectedProject.IX_Project);
                MaterialListItems.Clear();
                foreach (ProjectTaskTimeModel model in projectTaskTimes)
                {
                    MaterialListItems.Add(model);
                }
                OnPropertyChanged("MaterialListItems");
            }
            catch (Exception ex)
            {
                await _logger.WriteErrorAsync(new ErrorModel { Level = "High", Logger = typeof(MaterialListViewModel).FullName, Message = ex.Message, StackTrace = ex.StackTrace });
            }  
        }

        private async Task RefreshCommand()
        {
            try
            {
                await LoadMaterialData();
            }
            catch (Exception ex)
            {
                await _logger.WriteErrorAsync(new ErrorModel { Level = "High", Logger = typeof(MaterialListViewModel).FullName, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }

        public async Task SetSelectedProject(ProjectModel value)
        {
            if (value == null)
                return;

            _selectedProject = value;
            await LoadMaterialData();

        }

    }
}
