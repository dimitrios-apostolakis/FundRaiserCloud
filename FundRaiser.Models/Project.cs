using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Models
{
    public class Project
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Project Goal")]
        [Range(10, 1000000, ErrorMessage = "The funding goal must be between 10 to 1 million euros.")]
        public double ProjectGoal { get; set; }
        [Range(7, 60, ErrorMessage = "The funding period must be between 7 to 60 days.")]
        public int Days { get; set; }
        [Required]
        [Range(1, 8, ErrorMessage = "The Number of Rewards must be between 1 to 8.")]
        [DisplayName("Number of Rewards")]
        public int NumberOfBenefits { get; set; }

        public string Image { get; set; }
        
        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //List of all Backers
        public List<Backer> Backers { get; set; } = new();

        public int ProjectCreatorId { get; set; }
        public ProjectCreator ProjectCreator { get; set; }

        //List of all benefits for current project
        public List<Benefit> ProjectBenefits { get; set; } = new();

        //status progress

        //public string UserId { get; set; }
        //
        //public DateTime StartDate { get; set; } = DateTime.Now;

        //public AspNetUsers User { get; set; }
        //public ICollection<Benefit> Benefit { get; set; }
        //public ICollection<UsersBenefits> UsersBenefits { get; set; }

        //public Project()
        //{
        //    Benefit = new List<Benefit>();
        //}

    }
}
