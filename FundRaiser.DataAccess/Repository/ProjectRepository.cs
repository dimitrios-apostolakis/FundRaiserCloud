using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Project obj)
        {
            //_db.Project/*.Include(u => u.Category)*/.Include(u => u.ProjectCreator);
            var objFromDb = _db.Project.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Title = obj.Title;
            objFromDb.Description = obj.Description;
            objFromDb.Days = obj.Days;
            objFromDb.ProjectGoal = obj.ProjectGoal;
            objFromDb.NumberOfBenefits = obj.NumberOfBenefits;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.Category = obj.Category;
            objFromDb.Backers = obj.Backers;
            objFromDb.ProjectCreator = obj.ProjectCreator;
            objFromDb.ProjectBenefits = obj.ProjectBenefits;
            if (objFromDb.Image != null )
            {
                objFromDb.Image= obj.Image;
            }
        }
    }
}
