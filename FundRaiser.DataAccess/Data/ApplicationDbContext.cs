using FundRaiser.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FundRaiser.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Benefit> Benefit { get; set; }
        public DbSet<Dashboard> Dashboard { get; set; }
        
    }
}
