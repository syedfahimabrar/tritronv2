using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public class LanguageRepository:Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext context) : base(context)
        {

        }
    }
}
