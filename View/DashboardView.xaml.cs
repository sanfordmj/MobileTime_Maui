
using MobileTime.Helper;
using MobileTime.ViewModel;

namespace MobileTime.View
{

	public partial class DashboardView : ContentView
	{
		public DashboardView()
		{
			ViewModel = ServiceResolver.Resolve<DashboardViewModel>();
			BindingContext = ViewModel;

			InitializeComponent();

		}
		public DashboardViewModel ViewModel
		{
			get { return BindingContext as DashboardViewModel; }
			set { BindingContext = value; }
		}


		private void OnJobCommand(object sender, EventArgs e)
        {
			ViewModel.OnJobCommand.Execute(null);
        }

	}
}