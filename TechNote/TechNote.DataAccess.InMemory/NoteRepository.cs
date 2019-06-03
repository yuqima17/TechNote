using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core;

namespace TechNote.DataAccess.InMemory
{
    public class NoteRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Note> notes = new List<Note>();
        public NoteRepository()
        {
            notes = cache["notes"] as List<Note>;
            if (notes == null)
            {
                notes = new List<Note>();
            }
        }
        public void Commit()
        {
            cache["notes"] = notes;
        }
        public void Insert(Note n)
        {
            notes.Add(n);
        }
        public Note Find(string id)
        {
            Note noteFound = notes.Find(i => i.Id == id);
            if (noteFound == null)
            {
                throw new Exception("Note Not Found");
            }
            else
            {
                return noteFound;
            }
            
            
        }
        public void Update(Note n)
        {
            Note noteUpdate = notes.Find(i => i.Id == n.Id);
            if (noteUpdate==null)
            {
                throw new Exception("Note Not Found");
            }
            else
            {
                noteUpdate.Title = n.Title;
                noteUpdate.Description = n.Description;
                noteUpdate.NoteContent = n.NoteContent;
                noteUpdate.dateModified = DateTime.Now.ToString();
            }
        }
        public void Delete(string id)
        {
            Note noteDelete = notes.Find(i => i.Id == id);
            if (noteDelete == null)
            {
                throw new Exception("Note Not Found");
            }
            else
            {
                notes.Remove(noteDelete);
            }

        }
        public IQueryable<Note> Collections()
        {
            return notes.AsQueryable();
        }

    }
}
