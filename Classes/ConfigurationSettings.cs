using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Classes
{
    internal class ConfigurationSettings
    {        
        public JwtBearerConfiguration JwtBearerConfiguration { get; set; } = new JwtBearerConfiguration();
        public ServiceEndpoint ServiceEndpoint { get; set; } = new ServiceEndpoint();
    }

    internal class JwtBearerConfiguration
    {
        public TokenValidationConfiguration TokenValidationConfiguration { get; set; } = new TokenValidationConfiguration();
        public string Authority { get; set; }
        public string IssuerSigningKey { get; set; }
    }
    internal class TokenValidationConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
    internal class ServiceEndpoint
    {
        public string AuthServer { get; set; }
        public string WebApiService { get; set; } = "http://google.com";
    }
}
