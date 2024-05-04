using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Orgs
{
    public class Organization : Aggregate<long>
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Describe { get; set; }

        public required DateTime CreatedTime { get; set; }

        public required long CreateUserId { get; set; }

        public static Organization CreateTeam(string name, string description, long userId)
        {
            return new Organization
            {
                Name = name,
                Describe = description,
                CreateUserId = userId,
                CreatedTime = DateTime.Now,
            };
        }
    }
}
