using Maui.Plugins.PageResolver;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.LifecycleEvents;
using MobileTime.Helper;
using System.Reflection;
using Telerik.Maui.Controls.Compatibility;

namespace MobileTime;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var a = Assembly.GetExecutingAssembly();
		string[] names = a.GetManifestResourceNames();

		using var stream = a.GetManifestResourceStream("MobileTime.appsettings.json");

		var config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();
		
		var builder = MauiApp.CreateBuilder();
		builder
			.UseTelerik()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Configuration.AddConfiguration(config);
		builder.Services.ConfigureServices(config);
		builder.Services.ConfigureViewModels();
		builder.Services.ConfigureViews();
		builder.Services.UsePageResolver();
		builder.Services.UseServiceResolver();

		return builder.Build();
	}

}
