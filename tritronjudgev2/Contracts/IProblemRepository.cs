using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Models;

namespace Contracts
{
    public interface IProblemRepository
    {
        Problem Get(int id);
        IEnumerable<Problem> GetAll();
        IEnumerable<Problem> Find(Expression<Func<Problem, bool>> predicate,
            Func<IQueryable<Problem>, IOrderedQueryable<Problem>> orderBy = null,
            Func<IQueryable<Problem>, IIncludableQueryable<Problem, object>> include = null);

        IEnumerable<Problem> Find(Expression<Func<Problem, bool>> predicate,
            int pageNumber, int pageSize,
            Func<IQueryable<Problem>, IOrderedQueryable<Problem>> orderBy = null,
            Func<IQueryable<Problem>, IIncludableQueryable<Problem, object>> include = null);
        IEnumerable<Problem> Find(int pageNumber = 1, int pageSize = 5);
        int GetCount(Expression<Func<Problem, bool>> filter = null);
        Problem SingleOrDefault(Expression<Func<Problem, bool>> predicate);
        void Add(Problem entity);
        void AddRange(IEnumerable<Problem> entities);
        void Remove(Problem entity);
        void RemoveRange(IEnumerable<Problem> entities);
    }
}