using dws.models.ProjectManagement;

namespace MobileTime.Services.Interfaces
{
    public interface IProjectStore
    {
        Task<List<ProjectModel>> GetByCustomer(int IX_Customer);
        Task<ProjectModel> Get(int IX_Project);
        Task<ProjectModel> Post(ProjectModel model);
    }
}
