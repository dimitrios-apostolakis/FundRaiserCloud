using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FundRaiser.Models
{
    public class Benefit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Benefit Name")]
        public string Name { get; set; }
        [Display(Name = "Benefit Description")]
        public string Description { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public double Price { get; set; }

        //[ForeignKey("ProjectId")]
        //[Display(Name = "Project")]
        //public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Backer> Backers { get; set; } = new();
    }
}
