using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ProblemRepository :Repository<Problem>, IProblemRepository
    {
        public ProblemRepository(DbContext context):base(context)
        {
            
        }
    }
}
