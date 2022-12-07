using Crowdfunding.Models;
using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.DataAccess.Repository
{
    public class ProjectBenefitRepository : Repository<ProjectBenefit>, IProjectBenefitRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectBenefitRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(ProjectBenefit obj)
        {
            var objFromDb = _db.ProjectBenefit.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.BenefitId = obj.BenefitId;
            objFromDb.ProjectId = obj.ProjectId;
        }
    }
}
