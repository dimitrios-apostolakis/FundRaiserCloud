using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Models
{
    public class Dashboard
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Project Title")]
        public string Name { get; set; }
        public double Goal { get; set; }
        
        [DisplayName("Total Backers")]
        public int BackersSum { get; set; }
        [DisplayName("Pledged so far")]
        public double TotalPledged { get; set; }

        //public List<Benefit> Benefit = new List<Benefit>();
    }
}
