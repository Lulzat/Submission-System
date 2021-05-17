using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarkelApp.Models
{
    public class Submission
    {
        [Key]
        [DisplayName("Submission ID")]
        public int SubmissionId { get; set; }
        
        [DisplayName("Submission Name")]
        public string SubmissionName { get; set; }
        
        [DisplayName("Details")]
        public string SubmissionDetails { get; set; }
        
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        public List<Analysis> Analyses { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
