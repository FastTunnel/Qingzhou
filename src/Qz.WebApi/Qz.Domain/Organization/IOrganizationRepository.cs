using Qz.Domain.Repositorys.Base;

namespace Qz.Domain.Orgs
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        IEnumerable<Organization> ListOrgForCurrentUser(long userId);
    }
}
