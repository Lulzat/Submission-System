using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarkelApp.Models
{
    public class Analysis
    {
        [Key]
        public int AnalysisId { get; set; }

        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }

        public int AggLimit_1 { get; set; }

        public int AggLimit_2 { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
