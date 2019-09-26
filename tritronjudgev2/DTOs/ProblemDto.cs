using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace tritronAPI.DTOs
{
    public class ProblemDto
    {
        public int Id { get; set; }
        public string ProblemName { get; set; }
        public string ProblemAuthorId { get; set; }
        public string AuthorName { get; set; }
        public AuthorDto ProblemAuthor { get; set; }
        //public virtual List<Resources> Resourceses { get; set; }
        public string ProblemDescription { get; set; }
        public bool IsPublished { get; set; }
        public string Tags { get; set; }
        //public Guid Contest_Id { get; set; }
        public virtual Contest Contest { get; set; }
        public int? Contest_Id { get; set; }
        public short Score { get; set; }

        //Timelimit in miliseconds
        public int TimeLimit { get; set; }

        //MemoryLimit in bytes
        public int MemoryLimit { get; set; }

        //More than source code limit is not allowed
        public int? SourceCodeLimit { get; set; }
        public ICollection<LanguageDTO> Languages { get; set; }
    }
}
