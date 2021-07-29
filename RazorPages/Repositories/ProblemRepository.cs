using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Repositories
{
    public class ProblemRepository
    {
        SqlDbContext context = new SqlDbContext();

        public IList<Problem> GetBy(IList<ProblemStatus> exclude, bool hasSummary, bool desc)
        {
            IQueryable<Problem> problems = context.Problems;
            if (exclude != null)
            {
                problems = problems.GetExclude(exclude);
            }//else nothing
            if (hasSummary)
            {
                problems = problems.GetHasSummary();
            }
            problems.GetOrderByPublishTime(desc);
            return problems.ToList();

        }
    }
    public static class ExtensionMethods
    {
        public static IQueryable<Problem> GetHasSummary(this IQueryable<Problem> problems)
        {
            return problems.Where(p => p.Rrward > 0);
        }
        public static IQueryable<Problem> GetOrderByPublishTime(this IQueryable<Problem> problems, bool desc = true)
        {
            if (!desc)
            {
                return problems.OrderBy(p => p.PublishTime);
            }
            else
            {
                return problems.OrderByDescending(p => p.PublishTime);
            }
        }
        public static IQueryable<Problem> GetExclude(this IQueryable<Problem> problems, IList<ProblemStatus> exclude)
        {
            foreach (var item in exclude)
            {
                problems=problems.Where(p => p.Status != item);
            }
            return problems;
        }
    }
}
