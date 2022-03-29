using MobileTime.ViewModel;

namespace MobileTime.ViewHelper
{

	public partial class SearchList : ContentPage
	{
		
		public SearchList(SearchListViewModel viewModel)
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();			
			ViewModel = viewModel;
			ViewModel.SearchViewModel.Clear();
			BindingContext = viewModel;
		}

		public SearchListViewModel ViewModel
		{
			get { return BindingContext as SearchListViewModel; }
			set { BindingContext = value; }
		}
		
		private void listView_RefreshRequested(object sender, Telerik.XamarinForms.DataControls.ListView.PullToRefreshRequestedEventArgs e)
        {
			ViewModel.OnRefreshCommand.Execute(null);
			listView.EndRefresh();
		}

        private void RadEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
			if (e.NewTextValue != null && e.NewTextValue.Length > 2)
				ViewModel.OnFilterCommand.Execute(e.NewTextValue);
        }

        private void listView_LoadOnDemand(object sender, EventArgs e)
        {
			ViewModel.OnFilterCommand.Execute("");
        }

        private void listView_SelectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
			ViewModel.OnSelectCommand.Execute(listView.SelectedItem);

		}
		private void OnCancelClicked(object sender, EventArgs e)
		{
			ViewModel.OnCancelCommand.Execute(null);
		}

		private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
		{			
			listView.SelectedItem = null;
			ViewModel.OnGestureRecognizerButtonCommand.Execute(null);			
		}

        private void RadButton_Clicked(object sender, EventArgs e)
        {
			ViewModel.OnInfoButtonCommand.Execute(null);			
		}
    }
}