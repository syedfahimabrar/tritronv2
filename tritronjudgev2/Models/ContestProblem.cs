using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ContestProblem
    {
        public Contest Contest { get; set; }
        public Problem Problem { get; set; }
        public int ContestId { get; set; }
        public int ProblemId { get; set; }
        [StringLength(1,ErrorMessage = "only one char")]
        [RegularExpression("^[A-Z]")]
        public string ProblemNumber { get; set; }
    }
}
