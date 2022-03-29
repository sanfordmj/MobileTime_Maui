
using MobileTime.Classes;
using MobileTime.Helper;
using MobileTime.ViewModel;

namespace MobileTime.View
{

	public partial class JobView : ContentPage
    {

        public string ListCustomerSearchType { get; set; }
        public string ListJobSearchType { get; set; }

        public JobView()
		{
            //Borken in this Maui version
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            
            ViewModel = ServiceResolver.Resolve<JobViewModel>();
            BindingContext = ViewModel;

            ListCustomerSearchType = "Customer";
            ListJobSearchType = "Job";

            JobStartTime.BindingContext = ViewModel.JobStartTime;
            JobStartTime.Placeholder = ViewModel.JobStartTime.TimeOfDay;
            JobStartTime.Time = ViewModel.JobStartTime.TimeOfDay;

            lunch.BindingContext = ViewModel.JobStartTime;
            lunch.Placeholder = ViewModel.JobStartTime.TimeOfDay;
            lunch.Time = new TimeSpan(0, 0, 30, 0);

            JobEndTime.BindingContext = ViewModel.JobStartTime;
            JobEndTime.Placeholder = ViewModel.JobStartTime.TimeOfDay;
            JobEndTime.Time = ViewModel.JobStartTime.TimeOfDay;

            this.Appearing += JobView_Appearing;
            
        }
        
        private async void JobView_Appearing(object sender, EventArgs e)
        {

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            Task.Run(async () =>
            {
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    BusyJobIndicatorAsset.IsVisible = true;
                    await Task.Delay(2000);
                    BusyJobIndicatorAsset.IsVisible = false;
                    BaseViewModel.SetIsLoading(false);
                });
            });
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

            this.Appearing -= JobView_Appearing;
        }

        public JobViewModel ViewModel
        {
            get { return BindingContext as JobViewModel; }
            set { BindingContext = value; }
        }

        private void OnSaveCommand(object sender, EventArgs e)
        {
            //ViewModel.CommandSaveJob.Execute(null);
        }

        private void OnCancelCommand(object sender, EventArgs e)
        {
            ViewModel.OnCancelCommand.Execute(null);
        }

        private void OnMaterialList_Clicked(object sender, EventArgs e)
        {
            ViewModel.OnShowMaterialListViewCommand.Execute(null);
        }

        private void OpenPopup(object sender, EventArgs e)
        {
            popup.IsOpen = true;
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            popup.IsOpen = false;
        }

        private void OpenListPopup(object sender, EventArgs e)
        {
            listpopup.IsOpen = true;
        }

        private void CloseListPopup(object sender, EventArgs e)
        {
            listpopup.IsOpen = false;
        }
    }

}