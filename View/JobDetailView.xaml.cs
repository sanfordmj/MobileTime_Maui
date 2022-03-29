
using MobileTime.ViewModel;

namespace MobileTime;

public partial class JobDetailView : ContentPage
{
	public JobDetailView(JobDetailViewModel viewModel)
	{
		NavigationPage.SetHasNavigationBar(this, false);
		ViewModel = viewModel;
		BindingContext = ViewModel;
		InitializeComponent();
	}

	public JobDetailViewModel ViewModel
	{
		get { return BindingContext as JobDetailViewModel; }
		set { BindingContext = value; }
	}

    private void OnCancelCommand(object sender, EventArgs e)
    {
		ViewModel.OnCancelCommand.Execute(null);
    }

    private void OnSaveCommand(object sender, EventArgs e)
    {
		ViewModel.OnSaveCommand.Execute(null);
    }
}