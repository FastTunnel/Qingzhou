using Qz.Domain.Repositorys.Base;
using Qz.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Domain.Teams
{
    public class Team : Aggregate<Identifier>
    {
        public Identifier Id { get; set; }

        public required TeamName Name { get; set; }

        public required string Description { get; set; }

        public required DateTime CreatedTime { get; set; }

        public required long CreateUserId { get; set; }

        public static Team CreateTeam(string name, string description, long userId)
        {
            return new Team
            {
                Name = new TeamName(name),
                Description = description,
                CreateUserId = userId,
                CreatedTime = DateTime.Now,
            };
        }

        public Identifier GetId()
        {
            return Id;
        }
    }
}
