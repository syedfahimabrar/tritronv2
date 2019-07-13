using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using tritronAPI.Model;

namespace tritronAPI.DTOs
{
    public class ProblemCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string ProblemName { get; set; }
        public string ProblemAuthorId { get; set; }
        public string AuthorName { get; set; }
        //public virtual List<Resources> Resourceses { get; set; }
        public string ProblemDescription { get; set; }
        public string Tags { get; set; }
        public int Contest_Id { get; set; }
        public short Score { get; set; }

        //Timelimit in miliseconds
        public int TimeLimit { get; set; }

        //MemoryLimit in bytes
        public int MemoryLimit { get; set; }

        //More than source code limit is not allowed
        public int? SourceCodeLimit { get; set; }
        public byte[] InputData { get; set; }

        /// <remarks>
        /// Using byte[] (compressed with zip) to save database space.
        /// </remarks>
        public byte[] OutputData { get; set; }
    }
}
