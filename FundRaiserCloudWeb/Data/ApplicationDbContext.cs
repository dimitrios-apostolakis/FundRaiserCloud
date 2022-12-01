using FundRaiserWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FundRaiserCloudWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
    }
}
