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
        public int ErrorCode { get; set; }
        public double Amount { get; set; }
        public string ErrorText { get; set; }
    }
}
