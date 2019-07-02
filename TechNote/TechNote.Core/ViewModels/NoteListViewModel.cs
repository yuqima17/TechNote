using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core.Models;

namespace TechNote.Core.ViewModels
{
    public class NoteListViewModel
    {
        public List<Note> notes { get; set; }
        public List<CodingLanguage> codingLanguages { get; set; }
        public List<NoteType> noteTypes { get; set; }
        public NoteListViewModel() { }
    }
}
