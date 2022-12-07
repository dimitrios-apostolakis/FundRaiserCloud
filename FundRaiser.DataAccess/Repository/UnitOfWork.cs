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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Project = new ProjectRepository(_db);
            Benefit = new BenefitRepository(_db);
            Dashboard = new DashboardRepository(_db);
            Transaction = new TransactionRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IProjectRepository Project { get; private set; }
        public IBenefitRepository Benefit { get; private set; }
        public IDashboardRepository Dashboard { get; private set; }
        public ITransactionRepository Transaction { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
