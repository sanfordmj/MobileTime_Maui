
using dws.models.Logging;
using dws.models.Organization;
using dws.models.ProjectManagement;
using MobileTime.Classes;
using MobileTime.Services.Interfaces;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MobileTime.ViewModel
{
    public class SearchListViewModel : BaseViewModel, IDisposable
    {
        public static string ListSearchType { get; set; }
        public string InputSearchText { get; set; }
        public bool RefreshList { get; set; }
        public bool IsInfoVisible { get; set; } = false;

        public static event EventHandler<SearchModel> SearchViewModelSelected;

        List<SearchModel> _SearchViewModelSearchCache = new List<SearchModel>();
        private SearchModel _SelectedSearchViewModel;

        public ICommand OnFilterCommand;
        public ICommand OnSelectCommand;
        public ICommand OnRefreshCommand;
        public ICommand OnGestureRecognizerButtonCommand;
        public ICommand OnInfoButtonCommand;
        public ICommand OnCancelCommand;

        private bool isLoadingMoreItems;
        private int lodCounter = 40;

        private ObservableCollection<SearchModel> _SearchModel;
        public ObservableCollection<SearchModel> SearchViewModel { get { return _SearchModel; } set { _SearchModel = value; OnPropertyChanged(); } }

        private ICustomerStore CustomerStore;
        private IProjectTaskStore ProjectTaskStore;
        private ILoggingStore LoggingStore;
        public SearchListViewModel(ICustomerStore customerStore, IProjectTaskStore projectTaskStore, ILoggingStore logging)
        {
            CustomerStore = customerStore;
            ProjectTaskStore = projectTaskStore;
            LoggingStore = logging;
            SearchViewModel = new ObservableCollection<SearchModel>();           
            OnFilterCommand = new Command<string>(async (string filter) => await LoadSearchViewModel(filter));
            OnSelectCommand = new Command<SearchModel>(vm => SelectSearchViewModel(vm));
            OnRefreshCommand = new Command<string>(async (string filter) => await RefreshListCommand(filter));
            OnInfoButtonCommand = new Command(async () => await InfoButtonCommand());
            OnGestureRecognizerButtonCommand = new Command(async () => await GestureRecognizerButtonCommand());
            OnCancelCommand = new Command(async () => await CancelCommand());
        }


        public bool IsLoadingMoreItems
        {
            get { return this.isLoadingMoreItems; }            
            set { this.isLoadingMoreItems = value; OnPropertyChanged("IsLoadingMoreItems"); }
        }

        public async Task InfoButtonCommand()
        {
            IsInfoVisible = true;
            OnPropertyChanged("IsInfoVisible");
        }

        public async Task GestureRecognizerButtonCommand()
        {
            IsInfoVisible = false;
            OnPropertyChanged("IsInfoVisible");
        }

        public SearchModel SelectedSearchViewModel
        {
            get
            {
                return _SelectedSearchViewModel;
            }
            set
            {
                _SelectedSearchViewModel = value;
                OnPropertyChanged("SelectedSearchViewModel");
            }
        }

        private async Task LoadItemsCommandExecute(string arg)
        {
            
        }

        private async Task SearchTextChange(string arg)
        {
            
        }

        private async Task RefreshListCommand(string filter)
        {
            SearchViewModel.Clear();
        }

        public async Task LoadSearchViewModel(string filter)
        {
            try
            {
                switch (ListSearchType)
                {
                    case "Customer":
                        List<CustomerModel> Customers = await CustomerStore.Get(1, filter, 0, 0);
                        foreach (CustomerModel model in Customers)
                        {
                            SearchViewModel.Add(new SearchModel(model.Name, ListSearchType, model.IX_Customer));
                        }
                        break;
                    case "Job":
                        List<ProjectTaskModel> Tasks = await ProjectTaskStore.GetByProject(1);
                        foreach (ProjectTaskModel model in Tasks)
                        {
                            SearchViewModel.Add(new SearchModel(model.Description, ListSearchType, model.IX_Project));
                        }
                        break;
                }

                /*
                if (App.CurrentPosition != null && String.IsNullOrEmpty(filter))
                {
                    _SearchViewModelSearchCache.Clear();
                    _SearchViewModelSearchCache = await CustomerStore.GetCustomers("Filter", Longitude, Latitude);
                    Customers = _CustomerSearchCache.ToObservableCollection();
                }
                else
                {
                    if (filter.Length < 2)
                    {
                        _CustomerSearchCache.Clear();
                        _CustomerSearchCache = await CustomerStore.GetCustomersAsync(App.AuthToken, filter, 0.0, 0.0);
                        Customers = _CustomerSearchCache.Where(a => a.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToObservableCollection();
                    }
                    else
                    {
                        Customers = _CustomerSearchCache.Where(a => a.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToObservableCollection();
                    }
                }
                */
                //OnPropertyChanged("Customers");
            }
            catch (Exception ex)
            {
                await LoggingStore.WriteErrorAsync(new ErrorModel { Level = "Test", Logger = "PageView", Message = "Message", StackTrace = "Stack" });
            }
        }

        public async Task CancelCommand()
        {
            Dispose();
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void SelectSearchViewModel(SearchModel model)
        {
            if (model == null)
                return;

            SelectedSearchViewModel = model;

            SearchViewModelSelected?.Invoke(this, model);
            Dispose();
        }

        public IEnumerable<SearchModel> GetNewItems()
        {
            
            var result = new List<SearchModel>();
            if (string.IsNullOrEmpty(ListSearchType))
                return result;

            switch (ListSearchType)
            {
                case "Customer":

                    for(int i = 0; i < this.lodCounter; i++)
                    {
                        result.Add(new SearchModel("Name : " + i, ListSearchType, i));
                    }

                    break;
                case "Job":
                    for (int i = 0; i < this.lodCounter; i++)
                    {
                        result.Add(new SearchModel("Job :" + i, ListSearchType, i));
                    }
                    break;

            }
            return result;
        }

        public void Dispose()
        {
            SearchViewModel.Clear();
            if (SearchViewModelSelected != null)
                SearchViewModelSelected = null;
            if (ListSearchType != null)
                ListSearchType = null;
            //if (SearchViewModel != null)
                //SearchViewModel = null;
        }
    }

    public class SearchModel
    {
        public string Name { get; set; }
        public int Key {  get ; set; }  
        public string Type { get; set; }   
        public SearchModel() { }
        public SearchModel(string name, string type, int key)
        {
            this.Name = name;
            this.Key = key;
            this.Type = type;
        }

    }

}
