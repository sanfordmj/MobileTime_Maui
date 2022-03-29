using dws.models.ProjectManagement;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services.MockDb
{
    public class ProjectTaskMock : IProjectTaskStore
    {
        public List<ProjectTaskModel> ProjectTasks { get; set; } = new List<ProjectTaskModel>();

        public ProjectTaskMock()
        {
            ProjectTasks.InsertRange(0, new List<ProjectTaskModel> { new ProjectTaskModel { Description = "Task 1", IX_Project = 1 }, new ProjectTaskModel { Description = "Task 2", IX_Project = 1 }, new ProjectTaskModel { Description = "Task 3", IX_Project = 1 } });
        }

        public async Task<List<ProjectTaskModel>> GetByProject(int IX_Project)
        {
            await Task.Delay(500);
            return ProjectTasks;
        }

        public async Task<ProjectTaskModel> Get(int IX_ProjectTask)
        {
            await Task.Delay(500);
            return ProjectTasks.Where(pt=>pt.IX_ProjectTask.Equals(IX_ProjectTask)).FirstOrDefault();
        }
    }
}
