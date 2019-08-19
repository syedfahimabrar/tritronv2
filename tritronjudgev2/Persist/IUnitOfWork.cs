﻿using System.Threading.Tasks;

namespace tritronAPI.Persist
{
    public interface IUnitOfWork
    {
        IProblemRepository ProblemRepository { get; }
        ITestRepository TestRepository { get; }
        IContestRepository ContestRepository { get; set; }
        ILanguageRepository LanguageRepository { get; set; }
        void Save();
        void Dispose();
    }
}