using System.Collections.Generic;
using Contracts;
using Extension;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ContestRepository:Repository<Contest>, IContestRepository
    {
        public ContestRepository(DbContext context) : base(context)
        {
        }
    }
}
