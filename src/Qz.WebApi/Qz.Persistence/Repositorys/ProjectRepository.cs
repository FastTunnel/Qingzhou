using AutoMapper;
using Dapper;
using Dommel;
using Qz.Domain.Projects;
using Qz.Persistence.Entitys;
using Qz.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Repositorys
{
    public class ProjectRepository : IProjectRepository
    {
        readonly QingZhouDbContext dbContext;
        readonly IMapper mapper;

        public ProjectRepository(QingZhouDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void Attach(Project aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(Project aggregate)
        {
            throw new NotImplementedException();
        }

        public Project? Find(long id)
        {
            var project = dbContext.Select<ProjectEntity>(x => x.Id == id).FirstOrDefault();
            return mapper.Map<Project>(project);
        }

        public void Remove(Project aggregate)
        {
            throw new NotImplementedException();
        }

        public long Save(Project aggregate)
        {
            var id = dbContext.Insert<ProjectEntity>(mapper.Map<ProjectEntity>(aggregate));
            aggregate.Id = Convert.ToInt64(id);

            return aggregate.Id;
        }
    }
}
