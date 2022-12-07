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
    public class DashboardRepository : Repository<Dashboard>, IDashboardRepository
    {
        private readonly ApplicationDbContext _db;

        public DashboardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Dashboard obj)
        {
            var objFromDb = _db.Dashboard.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
            objFromDb.Goal = obj.Goal;
            objFromDb.BackersSum = obj.BackersSum;
            objFromDb.TotalPledged = obj.TotalPledged;
        }
    }
}
