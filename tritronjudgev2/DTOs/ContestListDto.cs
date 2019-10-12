using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.DTOs
{
    public class ContestListDto
    {
        public ICollection<ContestDtoForList> Contests { get; set; }
        public int Total { get; set; }
    }
}
