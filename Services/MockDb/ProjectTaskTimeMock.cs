using dws.models.ProjectManagement;
using MobileTime.Services.Interfaces;

namespace MobileTime.Services.MockDb
{
    public class ProjectTaskTimeMock : IProjectTaskTimeStore
    {
        public List<ProjectTaskTimeModel> ProjectTaskTimes { get; set; } = new List<ProjectTaskTimeModel>();

        public ProjectTaskTimeMock()
        {
            ProjectTaskTimes.InsertRange(0, new List<ProjectTaskTimeModel> { new ProjectTaskTimeModel { WorkLog = "Work Log 1", IX_ProjectTaskTime = 1, IX_ProjectTask = 1 }, new ProjectTaskTimeModel { WorkLog = "Work Log 2", IX_ProjectTaskTime = 2, IX_ProjectTask = 2 }, new ProjectTaskTimeModel { WorkLog = "Work Log 3", IX_ProjectTaskTime = 3, IX_ProjectTask = 3 } });
        }
        public async Task<List<ProjectTaskTimeModel>> Get(int IX_Project)
        {
            await Task.Delay(500);

            return ProjectTaskTimes;

        }
    }
}
