using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public interface ITestRepository
    {
        TestFile Get(int id);
        IEnumerable<TestFile> GetAll();
        IEnumerable<TestFile> Find(Expression<Func<TestFile, bool>> predicate);
        IEnumerable<TestFile> Find(Expression<Func<TestFile, bool>> predicate, int pageNumber, int pageSize);
        IEnumerable<TestFile> Find(int pageNumber = 1, int pageSize = 5);
        int GetCount(Expression<Func<TestFile, bool>> filter = null);
        TestFile SingleOrDefault(Expression<Func<TestFile, bool>> predicate);
        void Add(TestFile entity);
        void AddRange(IEnumerable<TestFile> entities);
        void Remove(TestFile entity);
        void RemoveRange(IEnumerable<TestFile> entities);
    }
}