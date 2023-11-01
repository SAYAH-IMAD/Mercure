using MediatR;
using Mercure.Common;

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
