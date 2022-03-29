using dws.models.ProjectManagement;

namespace MobileTime.Services.Interfaces
{
    public interface IProjectTaskStore
    {
        Task<List<ProjectTaskModel>> GetByProject(int IX_Project);
        Task<ProjectTaskModel> Get(int IX_ProjectTask);
    }
}
