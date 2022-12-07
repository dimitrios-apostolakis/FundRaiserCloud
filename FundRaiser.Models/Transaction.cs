using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public Project Project { get; set; } = null!;

        public Backer Backer { get; set; } = null!;

        public bool ContainsBenefit { get; set; }

        public double InvestedVolume { get; set; }

        public Benefit? Benefit { get; set; }
    }
}
