﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Entitys
{
    public class OrganizationEntity
    {
        [Key]
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Describe { get; set; }

        public required long CreatedAt { get; set; }

        public required long CreatedBy { get; set; }
    }
}
