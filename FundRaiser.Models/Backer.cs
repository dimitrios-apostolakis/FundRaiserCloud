using FundRaiser.Models;
using System.ComponentModel.DataAnnotations;

namespace FundRaiser.Models
{
    public class Backer
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public List<Project> InvestedProjects { get; set; } = new List<Project>();

        public List<Benefit>? Benefits { get; set; }
    }
}
