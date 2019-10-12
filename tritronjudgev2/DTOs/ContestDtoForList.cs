using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.DTOs
{
    public class ContestDtoForList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BackgroundImage { get; set; }
        public string ContestType { get; set; }
    }
}
