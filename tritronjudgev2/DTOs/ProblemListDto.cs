using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace tritronAPI.DTOs
{
    public class ProblemListDto
    {
        public IEnumerable<Problem> Problem { get; set; }
        public int TotalCount { get; set; }
    }
}
