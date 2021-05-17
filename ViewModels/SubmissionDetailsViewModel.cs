using MarkelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkelApp.ViewModels
{
    public class SubmissionDetailsViewModel
    {
        public IEnumerable<Analysis> Analyses { get; set; }
        public IEnumerable<Submission> Submissions { get; set; }
    }
}
