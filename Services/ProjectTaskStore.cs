using dws.models.ProjectManagement;
using MobileTime.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services
{
    public class ProjectTaskStore : IProjectTaskStore
    {
        HttpClient _httpClient;
        public ProjectTaskStore(HttpClient client)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "JWT " + App.AuthToken);
        }

        public Task<ProjectTaskModel> Get(int IX_ProjectTask)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectTaskModel>> GetByProject(int IX_Project)
        {
            throw new NotImplementedException();
        }
    }
}
