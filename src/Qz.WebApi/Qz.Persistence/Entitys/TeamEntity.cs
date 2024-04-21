using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Entitys
{
    public class TeamEntity
    {
        [Key]
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Describe { get; set; }

        public required long CreatedTime { get; set; }

        public required long CreatedUser { get; set; }
    }
}
