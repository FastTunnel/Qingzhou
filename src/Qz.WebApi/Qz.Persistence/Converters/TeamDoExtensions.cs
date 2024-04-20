using Qz.Domain.Models;
using Qz.Domain.Types;
using Qz.Persistence.Entitys;
using Qz.Utility.Extensions;

namespace Qz.Persistence.Converters
{
    public static class TeamDoExtensions
    {
        public static Team ToTodoItem(this TeamEntity userDo)
        {
            return new Team
            {
                Id = new Identifier(userDo.id),
                CreatedTime = userDo.created_time.ToDateTime(),
                CreateUserId = userDo.created_user,
                Description = userDo.describe,
                Name = new TeamName(userDo.name),
            };
        }
    }
}
