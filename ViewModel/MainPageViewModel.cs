using MobileTime.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui.Plugins.PageResolver;
using System.Windows.Input;

namespace MobileTime.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private bool _IsLoading;
        public bool IsLoading { get { return _IsLoading; } set { _IsLoading = value; OnPropertyChanged("IsLoading"); } }

        public ICommand OnSelectionChangeCommand { get; private set; }


        public MainPageViewModel()
        {
            m_LoadingChanged += async (sender, e) =>
            {
                var newThread = new System.Threading.Thread(() =>
                {
                    Application.Current.Dispatcher.Dispatch(() =>
                    {
                        this.IsLoading = e;
                        OnPropertyChanged("IsLoading");
                    });
                });
                newThread.Start();

            };
            OnSelectionChangeCommand = new Command(() => SelectionChangeCommand());
        }

        private void SelectionChangeCommand()
        {
            SetIsLoading(false);            
        }
    }
}
