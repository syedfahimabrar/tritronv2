using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum ContestType
    {
        ICPC,
        IOI
    }
    public class Contest
    {
        public Contest()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DateLessThan("EndTime",ErrorMessage = "Start Time should be less then Endtime")]
        public DateTime StartTime { get; set; }
        [Required]
        [DateLessThan("EndTime", ErrorMessage = "Start Time should be less then Endtime")]
        public DateTime EndTime { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        public string BackgroundImage { get; set; }
        [Required]
        public ContestType ContestType { get; set; }
        public ICollection<ContestProblem> ContestProblems { get; set; }
    }
}
