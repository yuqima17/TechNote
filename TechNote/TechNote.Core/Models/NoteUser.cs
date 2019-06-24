using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNote.Core.Models
{
    public class NoteUser:BaseEntity
    {
        public string NickName { get; set; }

        public string ImageAddress { get; set; }
        public string Email { get; set; }
        
    }
}
