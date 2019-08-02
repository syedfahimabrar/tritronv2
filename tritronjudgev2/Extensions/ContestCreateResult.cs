using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tritronAPI.Model;

namespace tritronAPI.Extensions
{
    public class ContestCreateResult
    {
        public bool Succeeded { get; set; }
        public Contest Contest { get; set; }
        public string Error { get; set; }
    }
}
