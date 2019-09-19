using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Extension { get; set; }
        public ICollection<ProblemLanguage> ProblemLanguages { get; set; } 
    }
}
