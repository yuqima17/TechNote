using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core.Models;

namespace TechNote.DataAccess.InMemory
{
    public class CodingLanguageRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<CodingLanguage> codingLanguages = new List<CodingLanguage>();
        public CodingLanguageRepository()
        {
            codingLanguages = cache["codingLanguages"] as List<CodingLanguage>;
            if (codingLanguages == null)
            {
                codingLanguages = new List<CodingLanguage>();
            }
        }
        public void Commit()
        {
            cache["codingLanguages"] = codingLanguages;
        }
        public void Insert(CodingLanguage n)
        {
            codingLanguages.Add(n);
        }
        public CodingLanguage Find(string id)
        {
            CodingLanguage cFound = codingLanguages.Find(i => i.Id == id);
            if (cFound == null)
            {
                throw new Exception("Note Not Found");
            }
            else
            {
                return cFound;
            }
        }
        public void Update(CodingLanguage n)
        {
            CodingLanguage cUpdate = codingLanguages.Find(i => i.Id == n.Id);
            if (cUpdate == null)
            {
                throw new Exception("Note Not Found");
            }
            else
            {
                cUpdate.Name=n.Name;
            }
        }
        public void Delete(string id)
        {
            CodingLanguage cDelete = codingLanguages.Find(i => i.Id == id);
            if (cDelete == null)
            {
                throw new Exception("Note Not Found");
            }
            else
            {
                codingLanguages.Remove(cDelete);
            }

        }
        public IQueryable<CodingLanguage> Collections()
        {
            return codingLanguages.AsQueryable();
        }
    }
}
