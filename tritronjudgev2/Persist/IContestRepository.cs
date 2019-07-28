using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public interface IContestRepository
    {
        Contest Get(int id);
        IEnumerable<Contest> GetAll();
        IEnumerable<Contest> Find(Expression<Func<Contest, bool>> predicate);
        IEnumerable<Contest> Find(Expression<Func<Contest, bool>> predicate, int pageNumber, int pageSize);
        IEnumerable<Contest> Find( int pageNumber=1, int pageSize=5);
        Contest SingleOrDefault(Expression<Func<Contest, bool>> predicate);
        void Add(Contest entity);
        void AddRange(IEnumerable<Contest> entities);
        int GetCount(Expression<Func<Contest, bool>> filter = null);
        void Remove(Contest entity);
        void RemoveRange(IEnumerable<Contest> entities);
    }
}