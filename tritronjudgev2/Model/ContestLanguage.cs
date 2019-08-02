using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Model
{
    public class ContestLanguage
    {
        public Contest Contest { get; set; }
        public Language Language { get; set; }
        public int ContestId { get; set; }
        public string LanguageId { get; set; }
    }
}
