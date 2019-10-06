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
            this.Problems = new HashSet<Problem>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [DateLessThan("EndTime",ErrorMessage = "Start Time should be less then Endtime")]
        public DateTime StartTime { get; set; }
        [DateLessThan("EndTime", ErrorMessage = "Start Time should be less then Endtime")]
        public DateTime EndTime { get; set; }
        public string BackgroundImage { get; set; }
        public ICollection<Problem> Problems { get; set; }
        public ContestType ContestType { get; set; }
        public ICollection<ContestProblem> ContestProblems { get; set; }
    }
}
