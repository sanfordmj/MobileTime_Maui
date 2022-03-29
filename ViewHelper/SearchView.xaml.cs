
using MobileTime.ViewModel;
using System.ComponentModel;
using Telerik.XamarinForms.Input;

namespace MobileTime.ViewHelper
{

	public partial class SearchView : ContentView
	{

		public string LabelText { get { return (string)GetValue(LabelTextProperty); } set { SetValue(LabelTextProperty, value); } }
		public string InputText
		{
			get { return (string)GetValue(InputTextProperty); }
			set { SetValue(InputTextProperty, value); }
		}
		public string BackgroundHex { get { return (string)GetValue(BackgroundHexProperty); } set { SetValue(BackgroundHexProperty, value); } }
		public string ListDataSourceType { get { return (string)GetValue(ListDataSourceTypeProperty); } set { SetValue(ListDataSourceTypeProperty, value); } }
		public SearchModel SelectedSearchViewModel { get { return (SearchModel)GetValue(SelectedSearchViewModelProperty); } set { SetValue(SelectedSearchViewModelProperty, value); } }
		public bool IsAddButtonVisible { get { return (bool)GetValue(IsAddButtonVisibleProperty); } set { SetValue(IsAddButtonVisibleProperty, value); } }

		public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(SearchView), string.Empty);
		public static readonly BindableProperty InputTextProperty = BindableProperty.Create(nameof(InputText), typeof(string), typeof(SearchView), string.Empty);
		public static readonly BindableProperty BackgroundHexProperty = BindableProperty.Create(nameof(BackgroundHex), typeof(string), typeof(SearchView), "#FFFFFF");
		public static readonly BindableProperty ListDataSourceTypeProperty = BindableProperty.Create(nameof(ListDataSourceType), typeof(string), typeof(SearchView), string.Empty);
		public static readonly BindableProperty SelectedSearchViewModelProperty = BindableProperty.Create(nameof(SelectedSearchViewModel), typeof(SearchModel), typeof(SearchView), null);
		public static readonly BindableProperty IsAddButtonVisibleProperty = BindableProperty.Create(nameof(IsAddButtonVisible), typeof(bool), typeof(SearchView), false);



		public SearchView()
		{
			SearchViewModel viewModel = new SearchViewModel();
			InitializeComponent();
			ViewModel = viewModel;
			BindingContext = viewModel;
		}

		public SearchViewModel ViewModel
		{
			get { return BindingContext as SearchViewModel; }
			set { BindingContext = value; }
		}

		private void ClosePopup(object sender, EventArgs e)
		{
			//popup.IsOpen = false;
		}

        private void OnSearchClicked(object sender, EventArgs e)
        {
			ImageButton btn = (ImageButton)sender;
			
			ViewModel.OnShowSearchCommand.Execute(btn.CommandParameter);
        }

        private void OnAddNewCommand(object sender, EventArgs e)
        {
			ImageButton btn = (ImageButton)sender;
			ViewModel.OnAddNewCommand.Execute(btn.CommandParameter);
		}

    }
}