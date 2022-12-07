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
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _db;

        public TransactionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Transaction transaction)
        {
            var objFromDb = _db.Transaction.FirstOrDefault(u => u.Id == transaction.Id);
            objFromDb.Project = transaction.Project;
            objFromDb.Backer = transaction.Backer;
            objFromDb.ContainsBenefit = transaction.ContainsBenefit;
            objFromDb.InvestedVolume = transaction.InvestedVolume;
            objFromDb.Benefit = transaction.Benefit;
        }
    }
}
