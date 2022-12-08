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
    public class BenefitRepository : Repository<Benefit>, IBenefitRepository
    {
        private readonly ApplicationDbContext _db;

        public BenefitRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Benefit obj)
        {
            var objFromDb = _db.Benefit.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.Price = obj.Price;
            objFromDb.ProjectId = obj.ProjectId;
            objFromDb.Project = obj.Project;
            objFromDb.Backers = obj.Backers;
        }
    }
}
