using Microsoft.Extensions.Configuration;
using MobileTime.Classes;
using MobileTime.Services;
using MobileTime.Services.Interfaces;
using MobileTime.Services.MockDb;
using MobileTime.View;
using MobileTime.ViewHelper;
using MobileTime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Helper
{
    public static class InjectorContainer
    {
        
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            Uri serviceEndpoint = new Uri(configuration.GetSection("ServiceEndpoint:WebApiService").Value);
            services.AddSingleton<IPageService, PageService>();
            services.AddHttpClient<ILoggingStore, LoggingStore>(client =>
            {
                client.BaseAddress = serviceEndpoint;
            });
            if (App.IsInTest)
            {
                services.AddSingleton<ICustomerStore, CustomerMock>();                
                services.AddSingleton<IProjectStore, ProjectMock>();
                services.AddSingleton<IProjectTaskStore, ProjectTaskMock>();
                services.AddSingleton<IProjectTaskTimeStore, ProjectTaskTimeMock>();
            }
            else
            {
                services.AddHttpClient<ICustomerStore, CustomerStore>(client =>
                {
                    client.BaseAddress = new Uri(serviceEndpoint + "Customer/");
                });                
                services.AddHttpClient<IProjectStore, ProjectStore>(client =>
                {
                    client.BaseAddress = new Uri(serviceEndpoint + "Project/");
                });
                services.AddHttpClient<IProjectTaskStore, ProjectTaskStore>(client =>
                {
                    client.BaseAddress = new Uri(serviceEndpoint + "ProjectTask/");
                });
                services.AddHttpClient<IProjectTaskTimeStore, ProjectTaskTimeStore>(client =>
                {
                    client.BaseAddress = new Uri(serviceEndpoint + "ProjectTaskTime/");
                });
            }
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainPageViewModel>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<SearchListViewModel>();
            services.AddSingleton<JobViewModel>();
            services.AddTransient<SearchViewModel>();
            services.AddSingleton<AssetViewModel>();
            services.AddSingleton<ExpenseViewModel>();
            services.AddSingleton<MaterialListViewModel>();
            services.AddSingleton<JobDetailViewModel>();
            services.AddSingleton<JobSearchViewModel>();
            return services;
        }

        public static IServiceCollection ConfigureViews(this IServiceCollection services)
        {   
            services.AddTransient<MainPageView>();
            services.AddTransient<AssetView>();
            services.AddTransient<DashboardView>();
            services.AddTransient<ExpenseView>();
            services.AddTransient<JobView>();
            services.AddTransient<SearchView>();
            services.AddTransient<SearchList>();
            services.AddTransient<MaterialListView>();
            services.AddTransient<JobDetailView>();
            services.AddTransient<JobSearchView>();
            return services;
        }
    }
}
