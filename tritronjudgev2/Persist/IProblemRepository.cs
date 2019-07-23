using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public interface IProblemRepository
    {
        Problem Get(int id);
        IEnumerable<Problem> GetAll();
        IEnumerable<Problem> Find(Expression<Func<Problem, bool>> predicate);
        IEnumerable<Problem> Find(Expression<Func<Problem, bool>> predicate, int pageNumber, int pageSize);
        IEnumerable<Problem> Find(int pageNumber = 1, int pageSize = 5);
        int GetCount(Expression<Func<Problem, bool>> filter = null);
        Problem SingleOrDefault(Expression<Func<Problem, bool>> predicate);
        void Add(Problem entity);
        void AddRange(IEnumerable<Problem> entities);
        void Remove(Problem entity);
        void RemoveRange(IEnumerable<Problem> entities);
    }
}