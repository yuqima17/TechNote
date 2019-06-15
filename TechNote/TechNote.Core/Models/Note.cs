using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNote.Core.Models;

namespace TechNote.Core
{
    public class Note:BaseEntity
    {



       
 
        public string dateModified { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [StringLength(2000)]
        public string NoteContent { get; set; }
        //code samples () sample:string of code

        public string CodingLanguage { get; set; }
        public string Type { get; set; }

    }
}
