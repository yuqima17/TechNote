using System.Linq;
using TechNote.Core.Models;

namespace TechNote.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collections();
        void Commit();
        void Delete(string id);
        T Find(string id);
        void Insert(T t);
        void Update(T t);
    }
}