using dws.models.ProjectManagement;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services
{
    public class ProjectStore : IProjectStore
    {
        public Task<ProjectModel> Get(int IX_Project)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectModel>> GetByCustomer(int IX_Customer)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectModel> Post(ProjectModel model)
        {
            throw new NotImplementedException();
        }
    }
}
