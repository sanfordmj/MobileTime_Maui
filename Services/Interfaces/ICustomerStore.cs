
using dws.models.Organization;

namespace MobileTime.Services.Interfaces
{
    public interface ICustomerStore
    {
        Task<List<CustomerModel>> Get(int IX_Company, string Filter, double Lng, double Lat);
        Task<CustomerModel> Get(int IX_Customer);
    }
}
