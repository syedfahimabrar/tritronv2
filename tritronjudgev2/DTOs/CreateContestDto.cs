using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tritronAPI.Model;

namespace tritronAPI.DTOs
{
    public class CreateContestDto
    {
        public CreateContestDto()
        {
            this.Problems = new HashSet<int>();
        }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string BackgroundImage { get; set; }
        public string Description { get; set; }
        public ICollection<int> Problems { get; set; }
    }
}
