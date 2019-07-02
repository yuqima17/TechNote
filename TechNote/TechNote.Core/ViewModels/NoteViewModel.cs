using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core.Models;

namespace TechNote.Core.ViewModels
{
    public class NoteViewModel
    {
        public Note note { get; set; }
        public IEnumerable<CodingLanguage> codingLanguages { get; set; }
        public IEnumerable<NoteType> noteTypes { get; set; }
        public NoteViewModel()
        {

        }
    }
}
