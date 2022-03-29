using MobileTime.Classes;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.ViewModel
{
    public class JobSearchViewModel : BaseViewModel
    {

        IPageService _pageService = null;
        ILoggingStore _loggingStore = null; 
        IProjectStore _projectStore = null; 

        public JobSearchViewModel(IPageService pageService, ILoggingStore loggingStore, IProjectStore projectStore)
        {
            _pageService = pageService;
            _loggingStore = loggingStore;
            _projectStore = projectStore;

        }
    }
}
