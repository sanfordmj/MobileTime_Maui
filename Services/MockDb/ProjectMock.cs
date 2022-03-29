using dws.models.ProjectManagement;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services.MockDb
{
    public class ProjectMock : IProjectStore
    {
        public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();

        public ProjectMock()
        {
            Projects.InsertRange(0, new List<ProjectModel> { new ProjectModel { ShortDescription = "Project 1", IX_Project = 1, IX_Customer = 1 }, new ProjectModel { ShortDescription = "Project 2", IX_Project = 1, IX_Customer = 2 }, new ProjectModel { ShortDescription = "Project 3", IX_Project = 1, IX_Customer = 2 } });
        }
        public async Task<List<ProjectModel>> GetByCustomer(int IX_Customer)
        {
            await Task.Delay(500);
            return Projects.Where(p=>p.IX_Customer.Equals(IX_Customer)).ToList();
        }

        public async Task<ProjectModel> Get(int IX_Project)
        {
            await Task.Delay(500);
            return Projects.Where(p => p.IX_Project.Equals(IX_Project)).FirstOrDefault();
        }

        public async Task<ProjectModel> Post(ProjectModel model)
        {
            await Task.Delay(500);
            Projects.Add(model);
            model.IX_Project = Projects.Count + 1;
            return model;
        }
    }
}
