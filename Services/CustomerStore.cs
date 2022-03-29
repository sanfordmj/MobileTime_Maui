using dws.models.Organization;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services
{
    public class CustomerStore : ICustomerStore
    {
        HttpClient _httpClient;
        public CustomerStore(HttpClient client)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "JWT " + App.AuthToken);
        }

        public Task<List<CustomerModel>> Get(int IX_Customer, string Filter, double Lng, double Lat)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> Get(int IX_Customer)
        {
            throw new NotImplementedException();
        }
    }
}
