using MobileTime.ViewModel;

namespace MobileTime;

public partial class MaterialListView : ContentPage
{

	public MaterialListView(MaterialListViewModel viewModel)
	{
		
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		ViewModel = viewModel;
	}


	public MaterialListViewModel ViewModel
	{
		get { return BindingContext as MaterialListViewModel; }
		set { BindingContext = value; }
	}

	private void listView_RefreshRequested(object sender, Telerik.XamarinForms.DataControls.ListView.PullToRefreshRequestedEventArgs e)
	{
		ViewModel.OnRefreshCommand.Execute(null);
		listView.EndRefresh();
	}

    private void OnCancelClicked(object sender, EventArgs e)
    {
		ViewModel.OnCancelCommand.Execute(null);
	}

    private void RadEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}