using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class LanguageRepository:Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext context) : base(context)
        {

        }
    }
}
