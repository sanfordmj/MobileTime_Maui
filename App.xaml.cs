using dws.models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobileTime.Classes;
using MobileTime.View;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MobileTime;

public partial class App : Application
{
    public static Location CurrentPosition;
    public const bool IsInTest = true;
    public static UserModel User = null;
    public const string APPNAME = "MobileTime";
    public static string AuthToken;
    public static int IX_Company;
    public static int IX_User;
    public static int IX_Location;
    private static IDictionary<string, string> _APPCLAIMS;
    public static IDictionary<string, string> APPCLAIMS { get => _APPCLAIMS; set => _APPCLAIMS = value; }

    public IConfiguration _config;

    public App(IConfiguration config)
    {

        InitializeComponent();
        _config = config;
        MainPage = new ContentPage();
        try
        {

            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1zIiwiVXNlck5hbWUiOiJtcyIsIkl4VXNlciI6IjEiLCJJeExvY2F0aW9uIjoiMSIsIkl4Q29tcGFueSI6IjEiLCJuYmYiOjE2NDIxMDMxMjAsImV4cCI6MTY3MzYzOTEyMCwiaWF0IjoxNjQyMTAzMTIwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0L2RhdmNvLnN0cy8iLCJhdWQiOiJodHRwOi8vb2RhdGEuZGF2Y28uY29tLyJ9.5aVNCGt7PRMm5Ej8UTQEw7sYEXZHB2LrfziLcrp-ziU";
            //Task.Run(async () => token = await SecureStorage.GetAsync(APPNAME).ConfigureAwait(true)).Wait();
            if (token == null)
            {
                Task.Run(async () => await LoadLoginView());
            }
            else
            {
                App.AuthToken = token;
                ParseClaims().Wait();
                MainPage = new NavigationPage(new MainPageView());
                //MainPage = new MainPageView();
                
            }
        }
        catch (Exception ex)
        {
            //logging.WriteError(new dws.models.Logging.ErrorModel {  Level="High", Message=ex.Message, StackTrace = ex.StackTrace, CreateDate=DateTime.Now, Logger="App", Time_Stamp=DateTime.Now });
        }
    }

    private async Task ParseClaims()
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            ConfigurationSettings settings = _config.GetRequiredSection("AuthenticationConfiguration").Get<ConfigurationSettings>();
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.JwtBearerConfiguration.IssuerSigningKey));

            var securityToken = tokenHandler.ReadToken(App.AuthToken) as JwtSecurityToken;
            if (securityToken == null)
                throw new NullReferenceException();

            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = settings.JwtBearerConfiguration.TokenValidationConfiguration.Issuer,
                ValidAudience = settings.JwtBearerConfiguration.TokenValidationConfiguration.Audience,
                IssuerSigningKey = mySecurityKey
            };

            try
            {
                App.IX_User = Convert.ToInt32(securityToken.Claims.First(claim => claim.Type == "IxUser").Value);
                App.IX_Company = Convert.ToInt32(securityToken.Claims.First(claim => claim.Type == "IxCompany").Value);
                App.IX_Location = Convert.ToInt32(securityToken.Claims.First(claim => claim.Type == "IxLocation").Value);
            }
            catch (Exception ex)
            {
                string s = ex.Message;                
            }
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
    }

    private async Task LoadLoginView()
    {

        await Task.Delay(1000); //slow it down
        WebAuthenticatorResult r = null;
        Device.BeginInvokeOnMainThread(async () =>
        {
            string s = "";
            try
            {
                ConfigurationSettings settings = _config.GetRequiredSection("AuthenticationConfiguration").Get<ConfigurationSettings>();

                r = await WebAuthenticator.AuthenticateAsync(new Uri(settings.ServiceEndpoint.AuthServer), new Uri("com.davcomobiletime://localhost"));
                await SecureStorage.SetAsync(App.APPNAME, r.AccessToken);

                #pragma warning disable CS4014 // Because this call is not awaited
                Task.Run(async () =>
                {
                    await Task.Delay(3000); //required
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        App.AuthToken = r.AccessToken;
                        await ParseClaims();
                        MainPage = new MainPageView();
                    });
                });
#pragma warning restore CS4014 // Because this call is not awaited
            }
            catch (Exception ex)
            {
                await LoadLoginView();
            }
        });

    }
    
}
