
using MobileTime.Helper;
using MobileTime.ViewModel;

namespace MobileTime.View
{

	public partial class ExpenseView : ContentView
	{
		public ExpenseView()
		{
			ViewModel = ServiceResolver.Resolve<ExpenseViewModel>();
			BindingContext = ViewModel;

			InitializeComponent();

			
		}

		public ExpenseViewModel ViewModel
		{
			get { return BindingContext as ExpenseViewModel; }
			set { BindingContext = value; }
		}

		private void OnSaveCommand(object sender, EventArgs e)
		{
			//ViewModel.CommandSaveJob.Execute(null);
		}


	}



}