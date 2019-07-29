using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tritronAPI.Model;

namespace tritronAPI.DTOs
{
    public class CreateContestDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }
        public string BackgroundImage { get; set; }
        public string Description { get; set; }
        public ICollection<Problem> Problems { get; set; }
    }
}
