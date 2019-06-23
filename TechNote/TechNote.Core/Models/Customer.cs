using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNote.Core.Models
{
    public class Customer:BaseEntity
    {
        public string NickName { get; set; }

        public string ImageAddress { get; set; }
        
    }
}
