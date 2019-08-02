using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Model
{
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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BackgroundImage { get; set; }
        public ICollection<Problem> Problems { get; set; }
        public ICollection<ContestLanguage> ContestLanguage { get; set; }
    }
}
