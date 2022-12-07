﻿using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.DataAccess.Repository.IRepository
{
    public interface IDashboardRepository : IRepository<Dashboard>
    {
        void Update(Dashboard obj);
    }
}
