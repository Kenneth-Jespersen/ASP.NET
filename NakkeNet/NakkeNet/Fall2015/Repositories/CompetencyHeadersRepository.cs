using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using NakkeNet.Models;

namespace NakkeNet.Repositories
{
    public interface ICompetencyHeadersRepository
    {
        IQueryable<CompetencyHeader> All { get; }

        IQueryable<CompetencyHeader> AllIncluding(
            params Expression<Func<CompetencyHeader, object>>[] includeProperties);

        CompetencyHeader Find(int id);
        void InsertOrUpdate(CompetencyHeader competencyHeader);
        void Delete(int id);
        void Save();
    }

    public class CompetencyHeadersRepository : ICompetencyHeadersRepository
    {
        ApplicationDbContext context =
            new ApplicationDbContext();

        public IQueryable<CompetencyHeader> All
        {
            get { return context.CompetencyHeaders; }
        }

        public IQueryable<CompetencyHeader> AllIncluding(
            params Expression<Func<CompetencyHeader, object>>[] includeProperties)
        {
            IQueryable<CompetencyHeader> query = context.CompetencyHeaders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CompetencyHeader Find(int id)
        {
            return context.CompetencyHeaders.Find(id);
        }

        public void InsertOrUpdate(CompetencyHeader competencyHeader)
        {
            if (competencyHeader.CompetencyHeaderId == 0) //new
            {
                context.CompetencyHeaders.Add(competencyHeader);
            }
            else //edit
            {
                context.Entry(competencyHeader).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            CompetencyHeader s = Find(id);
            context.CompetencyHeaders.Remove(s);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}