using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Model
{
    public class ContestProgrammingLanguage
    {
        public int Contest_id { get; set; }
        public string ProgrammingLanguage_Id { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual  ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
