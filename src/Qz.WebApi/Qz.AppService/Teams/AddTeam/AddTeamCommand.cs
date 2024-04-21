using MediatR;
using Qz.Application.Base.Commands;
using Qz.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Teams.AddTeam
{
    public class AddTeamCommand : ICommand<AddTeamResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long? UserId { get; set; }
    }
}
