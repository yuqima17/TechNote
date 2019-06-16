﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core.Contracts;
using TechNote.Core.Models;

namespace TechNote.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;
        public SQLRepository(DataContext context){
            this.context = context;
            this.dbSet = context.Set<T>();

}
        public IQueryable<T> Collections()
        {
            return dbSet;
            
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            T t=dbSet.Find(id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
                
            }
            dbSet.Remove(t);
        }

        public T Find(string id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
