using System.Collections.Generic;
using Contracts;
using Extension;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ContestRepository:Repository<Contest>, IContestRepository
    {
        public ContestRepository(DbContext context) : base(context)
        {
        }

        public ContestCreateResult CreateContest(Contest contest)
        {
            ICollection<Problem> problems = contest.Problems;
            contest.Problems = null;
            this.Context.Add(contest);
            foreach (var problem in problems)
            {
                var pro = this.Context.Find<Problem>(problem.Id);
                if (pro.Contest_Id != null)
                {
                    return new ContestCreateResult()
                    {
                        Succeeded = false,
                        Contest = null,
                        Error = "Problem Set cannot set in multiple contest.Use copy Problem Features"
                    };
                }
                pro.Contest_Id = contest.Id;
                this.Context.Update(pro);
            }

            return new ContestCreateResult(){Succeeded = true,Contest = contest,Error = null};
        }
    }
}
