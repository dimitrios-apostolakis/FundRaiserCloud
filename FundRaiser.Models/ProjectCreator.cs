using System.ComponentModel.DataAnnotations;

namespace FundRaiser.Models
{
    public class ProjectCreator
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public List<Project> CreatedProjects { get; set; } = new List<Project>();
    }
}
