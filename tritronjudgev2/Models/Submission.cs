using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Submission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }
        public virtual Problem Problem{get; set; }
        public int Problem_Id { get; set; }
        public string Language { get; set; }
        public byte[] Content { get; set; }
    }
}
