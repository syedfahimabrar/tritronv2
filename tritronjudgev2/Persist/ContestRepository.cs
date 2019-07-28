using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public class ContestRepository:Repository<Contest>, IContestRepository
    {
        public ContestRepository(DbContext context) : base(context)
        {
        }
    }
}
