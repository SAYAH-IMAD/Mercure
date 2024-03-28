using MediatR;
using Mercure.Common;
using Mercure.User.Application.Queries;
using Mercure.User.Application.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.User.API.Controllers
{
    public class ProfileController : ControllerBasic
    {
        public ProfileController(IMediator mediator) 
            : base(mediator)
        {
        }
    }
}
