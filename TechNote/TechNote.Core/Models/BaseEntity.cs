﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNote.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        public DateTimeOffset createdAt { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            createdAt = DateTime.Now;
        }
    }
}
