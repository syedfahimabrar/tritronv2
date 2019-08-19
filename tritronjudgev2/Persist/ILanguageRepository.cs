using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public interface ILanguageRepository
    {
        Language Get(int id);
        IEnumerable<Language> GetAll();
        IEnumerable<Language> Find(Expression<Func<Language, bool>> predicate);
        IEnumerable<Language> Find(Expression<Func<Language, bool>> predicate, int pageNumber, int pageSize);
        IEnumerable<Language> Find( int pageNumber=1, int pageSize=5);
        Language SingleOrDefault(Expression<Func<Language, bool>> predicate);
        void Add(Language entity);
        void AddRange(IEnumerable<Language> entities);
        int GetCount(Expression<Func<Language, bool>> filter = null);
        void Remove(Language entity);
        void RemoveRange(IEnumerable<Language> entities);
    }
}