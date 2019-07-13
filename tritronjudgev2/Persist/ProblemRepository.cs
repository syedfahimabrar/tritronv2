using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public class ProblemRepository :Repository<Problem>, IProblemRepository
    {
        public ProblemRepository(DbContext context):base(context)
        {
            
        }
    }
}
