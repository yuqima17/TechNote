using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core.Contracts;
using TechNote.Core.Models;

namespace TechNote.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T:BaseEntity
    {

        ObjectCache cache = MemoryCache.Default;
        List<T> items = new List<T>();
        string className;
        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }
        public void Commit()
        {
            cache[className] = items;
        }
        public void Insert(T t)
        {
            items.Add(t);
        }
        public T Find(string id)
        {
            T tFound = items.Find(i => i.Id == id);
            if (tFound == null)
            {
                throw new Exception(className+" Not Found");
            }
            else
            {
                return tFound;
            }
        }
        public void Update(T t)
        {
            T tUpdate = items.Find(i => i.Id == t.Id);
            if (tUpdate == null)
            {
                throw new Exception(className+" Not Found");
            }
            else
            {
                tUpdate = t;
            }
        }
        public void Delete(string id)
        {
            T tDelete = items.Find(i => i.Id == id);
            if (tDelete == null)
            {
                throw new Exception(className+" Not Found");
            }
            else
            {
                items.Remove(tDelete);
            }

        }
        public IQueryable<T> Collections()
        {
            return items.AsQueryable();
        }

    }
}
