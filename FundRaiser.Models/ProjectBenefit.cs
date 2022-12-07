using FundRaiser.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding.Models
{
    public class ProjectBenefit
    {
        [Key]
        public int Id { get; set; }
        public int BenefitId { get; set; }
        public int ProjectId { get; set; }
        public Benefit Benefit { get; set; }
        public Project Project { get; set; }
    }
}
