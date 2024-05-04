using Qz.Domain.Base.Repositorys;

namespace Qz.Domain.Organization
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        IEnumerable<Organization> ListOrgForCurrentUser(long userId);
    }
}
