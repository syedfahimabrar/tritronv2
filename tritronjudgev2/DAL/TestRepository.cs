using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class TestRepository:Repository<TestFile>, ITestRepository
    {
        public TestRepository(DbContext context) : base(context)
        {

        }
    }
}
