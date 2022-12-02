﻿using FundRaiser.Models;
using Microsoft.EntityFrameworkCore;

namespace FundRaiser.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
    }
}