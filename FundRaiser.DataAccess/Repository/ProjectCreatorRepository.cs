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
    public class ProjectCreatorRepository : Repository<ProjectCreator>, IProjectCreatorRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectCreatorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(ProjectCreator obj)
        {
            var objFromDb = _db.ProjectCreator.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.UserName = obj.UserName;
            objFromDb.Email = obj.Email;
            objFromDb.Password = obj.Password;
            objFromDb.RegistrationDate = obj.RegistrationDate;
            objFromDb.CreatedProjects = obj.CreatedProjects;
        }
    }
}
