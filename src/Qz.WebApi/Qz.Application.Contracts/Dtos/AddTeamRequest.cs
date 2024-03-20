using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts.Dtos
{
    public class AddTeamRequest : IRequest<AddTeamResponse>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public long? UserId { get; set; }
    }
}
