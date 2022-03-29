using MobileTime.Classes;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.ViewModel
{
    public class ExpenseViewModel : BaseViewModel
    {
        IPageService _pageService;
        ILoggingStore _loggingStore;
        public ExpenseViewModel(IPageService pageService, ILoggingStore loggingStore)
        {
            _loggingStore = loggingStore;
            _pageService = pageService;
        }

    }
}
