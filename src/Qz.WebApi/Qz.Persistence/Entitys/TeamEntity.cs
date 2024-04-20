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
        public long id { get; set; }

        public required string name { get; set; }

        public required string describe { get; set; }

        public required long created_time { get; set; }

        public required long created_user { get; set; }
    }
}
