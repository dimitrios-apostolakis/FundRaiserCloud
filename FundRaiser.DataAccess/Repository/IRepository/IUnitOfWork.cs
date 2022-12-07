using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProjectRepository Project { get; }
        IBenefitRepository Benefit { get; }
        IDashboardRepository Dashboard { get; }
        ITransactionRepository Transaction { get; }
        IProjectBenefitRepository ProjectBenefit { get; }
        
        void Save();
    }
}
