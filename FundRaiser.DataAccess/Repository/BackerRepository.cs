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
    public class BackerRepository : Repository<Backer>, IBackerRepository
    {
        private readonly ApplicationDbContext _db;

        public BackerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Backer obj)
        {
            var objFromDb = _db.Backer.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.UserName = obj.UserName;
            objFromDb.Email = obj.Email;
            objFromDb.Password = obj.Password;
            objFromDb.RegistrationDate = obj.RegistrationDate;
            objFromDb.InvestedProjects = obj.InvestedProjects;
            objFromDb.Benefits = obj.Benefits;
        }
    }
}
