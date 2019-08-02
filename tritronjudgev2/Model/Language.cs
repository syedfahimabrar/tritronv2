using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Model
{
    public class Language
    {
        [Key]
        public string Id { get; set; }
        public string Extension { get; set; }
        public ICollection<ContestLanguage> Contestlanguage { get; set; }
    }
}
