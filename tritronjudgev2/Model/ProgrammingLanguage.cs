using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Model
{
    public class ProgrammingLanguage
    {
        [Key]
        public string Name { get; set; }
        public string Extension { get; set; }
        public ICollection<ContestProgrammingLanguage> ContestProgrammingLanguages { get; set; }
    }
}
