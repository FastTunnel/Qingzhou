using MediatR;
using Qz.Application.Base.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Orgs.AddOrg
{
    public class AddTeamCommand : ICommand<AddTeamResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long? UserId { get; set; }
    }
}
