using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ContestProblem
    {
        public Contest Contest { get; set; }
        public Problem Problem { get; set; }
        public int ContestId { get; set; }
        public int ProblemId { get; set; }
    }
}
