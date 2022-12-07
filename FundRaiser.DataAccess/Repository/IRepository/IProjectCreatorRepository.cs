using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.DataAccess.Repository.IRepository
{
    public interface IProjectCreatorRepository : IRepository<ProjectCreator>
    {
        void Update(ProjectCreator obj);
    }
}
