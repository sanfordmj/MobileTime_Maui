using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services.Interfaces
{
    public interface IPageService
    {

        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
        Task PopAsync();
        Task PopModalAsync();
        Task DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);

    }
}
