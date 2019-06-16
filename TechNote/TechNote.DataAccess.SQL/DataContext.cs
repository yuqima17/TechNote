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
        public DataContext() : base("DefaultConnection")
        {

        }
        public DbSet<Note> notes { get; set; }
        public DbSet<CodingLanguage> codingLanguages { get; set; }
    }
}
