using dws.models.ProjectManagement;


namespace MobileTime.Services.Interfaces
{
    public interface IProjectTaskTimeStore
    {
        Task<List<ProjectTaskTimeModel>> Get(int IX_Project);
    }
}