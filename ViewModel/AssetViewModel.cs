using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.ViewModel
{
    public class AssetViewModel
    {
        IPageService _pageService;
        ILoggingStore _loggingStore;

        public AssetViewModel(IPageService pageService, ILoggingStore loggingStore)
        {
            _pageService = pageService;
            _loggingStore = loggingStore;
        }
    }
}
