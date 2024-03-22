using Qz.Domain.DomainPrimitive;
using Qz.Domain.Domains;
using Qz.Domain.Types;


namespace Qz.Persistence.Converters
{
    public static class TeamDoExtensions
    {
        public static Team ToTodoItem(this TeamDo userDo)
        {
            return new Team
            {
                Id = new Identifier(userDo.Id),
                CreatedTime = userDo.CreatedTime,
                CreateUserId = userDo.CreateUserId,
                Description = userDo.Description,
                Name = new TeamName(userDo.Name),
            };
        }
    }
}
