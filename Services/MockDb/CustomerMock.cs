using dws.models.Organization;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services.MockDb
{
    public class CustomerMock : ICustomerStore
    {
        public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
        public CustomerMock()
        {
            Customers.InsertRange(0, new List<CustomerModel> { new CustomerModel { Name = "Customer 1", IX_Customer = 1 }, new CustomerModel { Name = "Customer 2", IX_Customer = 2 }, new CustomerModel { Name = "Customer 3", IX_Customer = 3 } });
        }

        public async Task<List<CustomerModel>> Get(int IX_Company, string Filter, double Lng, double Lat)
        {
            await Task.Delay(500);
            return Customers;
        }

        public async Task<CustomerModel> Get(int IX_Customer)
        {
            await Task.Delay(500);
            return Customers.Where(c => c.IX_Customer.Equals(IX_Customer)).FirstOrDefault();
        }
    }
}
