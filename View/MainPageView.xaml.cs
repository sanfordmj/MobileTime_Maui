
using MobileTime.ViewModel;
using MobileTime.Helper;

namespace MobileTime.View
{
	public partial class MainPageView : ContentPage
    {
        public MainPageView()
        {
            var viewModel = ServiceResolver.Resolve<MainPageViewModel>();

            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            ViewModel = viewModel;
            BindingContext = ViewModel;
            tabView.SelectionChanged += TabView_SelectionChanged;        
            
        }

        private async void TabView_SelectionChanged(object sender, EventArgs e)
        {
            
            ViewModel.IsLoading = true;
            await BusyIndicatorAsset.FadeTo(1d);
            ViewModel.OnSelectionChangeCommand.Execute(null);            
        }

        public MainPageViewModel ViewModel { get; set; }

    }
}