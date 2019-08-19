using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Model
{
    public class ProblemLanguage
    {
        public Problem Problem { get; set; }
        public Language Language { get; set; }
        public int ProblemId { get; set; }
        public int LanguageId { get; set; }
    }
}
