using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum Languages
    {
        c,
        cpp,
        java,
        js,
        py
    }
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string ProblemName { get; set; }
        [ForeignKey("User")]
        public string ProblemAuthorId { get; set; }
        public virtual User ProblemAuthor { get; set; }
        public string AuthorName { get; set; }
        //public virtual List<Resources> Resourceses { get; set; }
        public string ProblemDescription { get; set; }
        public bool IsPublished { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public string Tags { get; set; }
        //public Guid Contest_Id { get; set; }
        public virtual Contest Contest { get; set; }

        [ForeignKey("Contest")]
        public int? Contest_Id { get; set; }
        public short Score { get; set; }

        //Timelimit in miliseconds
        public int TimeLimit { get; set; }

        //MemoryLimit in bytes
        public int MemoryLimit { get; set; }

        //More than source code limit is not allowed
        public int? SourceCodeLimit { get; set; }
        public virtual ICollection<TestFile> TestFiles { get; set; } = new List<TestFile>();
        public ICollection<ProblemLanguage> ProblemLanguages { get; set; }
        public ICollection<ContestProblem> ContestProblems { get; set; }
    }
}
