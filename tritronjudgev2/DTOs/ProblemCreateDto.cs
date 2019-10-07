using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.DTOs
{
    public class ProblemCreateDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string ProblemName { get; set; }
        [Required]
        public string ProblemAuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        //public virtual List<Resources> Resourceses { get; set; }
        [Required]
        public string ProblemDescription { get; set; }
        public string Tags { get; set; }
        public int? Contest_Id { get; set; }
        public short? Score { get; set; }
        public ICollection<string> InputTest { get; set; }
        public ICollection<string> OutputTest { get; set; }

        //Timelimit in miliseconds
        public int TimeLimit { get; set; }

        //MemoryLimit in bytes
        public int MemoryLimit { get; set; }

        //More than source code limit is not allowed
        public int? SourceCodeLimit { get; set; }
        public ICollection<TestFIleDto> Tests { get; set; }
        public ICollection<int> ProblemLanguages { get; set; }
        public bool IsPublished { get; set; }
    }
}
