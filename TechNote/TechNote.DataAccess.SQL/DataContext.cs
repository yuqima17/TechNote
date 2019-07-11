using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core;
using TechNote.Core.Models;

namespace TechNote.DataAccess.SQL
{
    public class DataContext:DbContext
    {
        public DataContext() : base("TechNoteApp")
        {

        }
        public DbSet<Note> notes { get; set; }
        public DbSet<CodingLanguage> codingLanguages { get; set; }
        public DbSet<NoteUser> noteUsers { get; set; }
        public DbSet<NoteType> noteTypes { get; set; }
    }
}
