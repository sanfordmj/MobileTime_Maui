using dws.models.ProjectManagement;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services
{
    public class ProjectTaskTimeStore : IProjectTaskTimeStore
    {
        public Task<List<ProjectTaskTimeModel>> Get(int IX_Project)
        {
            throw new NotImplementedException();
        }
    }
}
