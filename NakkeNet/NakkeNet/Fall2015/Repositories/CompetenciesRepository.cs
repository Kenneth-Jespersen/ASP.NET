using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using NakkeNet.Models;

namespace NakkeNet.Repositories
{
    public interface ICompetenciesRepository
    {
        IQueryable<Competency> All { get; }

        IQueryable<Competency> AllIncluding(
            params Expression<Func<Competency, object>>[] includeProperties);

        Competency Find(int id);
        void InsertOrUpdate(Competency competency);
        void Delete(int id);
        void Save();
    }

    public class CompetenciesRepository : ICompetenciesRepository
    {
        ApplicationDbContext context =
            new ApplicationDbContext();

        public IQueryable<Competency> All
        {
            get { return context.Competencies; }
        }

        public IQueryable<Competency> AllIncluding(
            params Expression<Func<Competency, object>>[] includeProperties)
        {
            IQueryable<Competency> query = context.Competencies;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Competency Find(int id)
        {
            return context.Competencies.Find(id);
        }

        public void InsertOrUpdate(Competency competency)
        {
            if (competency.CompetencyId == 0) //new
            {
                context.Competencies.Add(competency);
            }
            else //edit
            {
                context.Entry(competency).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Competency s = Find(id);
            context.Competencies.Remove(s);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}