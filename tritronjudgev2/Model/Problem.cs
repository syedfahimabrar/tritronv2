using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Model
{
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [MaxLength(GlobalConstants.ProblemNameMaxLength)]
        public string ProblemName { get; set; }
        public virtual User ProblemAuthor { get; set; }
        public virtual List<Resources> Resourceses { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ProblemDescription { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public string Tags { get; set; }
        //public Guid Contest_Id { get; set; }
        public virtual Contest Contest { get; set; }

        [ForeignKey("Contest")]
        public string? Contest_Id { get; set; }
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
