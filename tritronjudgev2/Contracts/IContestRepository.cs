using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Extension;
using Microsoft.EntityFrameworkCore.Query;
using Models;

namespace Contracts
{
    public interface IContestRepository
    {
        Contest Get(int id);
        IEnumerable<Contest> GetAll();
        IEnumerable<Contest> Find(Expression<Func<Contest, bool>> predicate,
            Func<IQueryable<Contest>, IOrderedQueryable<Contest>> orderBy = null,
            Func<IQueryable<Contest>, IIncludableQueryable<Contest, object>> include = null);

        IEnumerable<Contest> Find(Expression<Func<Contest, bool>> predicate,
            int pageNumber, int pageSize,
            Func<IQueryable<Contest>, IOrderedQueryable<Contest>> orderBy = null,
            Func<IQueryable<Contest>, IIncludableQueryable<Contest, object>> include = null);
        IEnumerable<Contest> Find( int pageNumber=1, int pageSize=5);
        Contest SingleOrDefault(Expression<Func<Contest, bool>> predicate);
        void Add(Contest entity);
        void AddRange(IEnumerable<Contest> entities);
        int GetCount(Expression<Func<Contest, bool>> filter = null);
        void Remove(Contest entity);
        void RemoveRange(IEnumerable<Contest> entities);
    }
}