using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.Common
{
    public class ControllerBasic : ControllerBase
    {
        public IMediator Mediator { get; private set; }

        public ControllerBasic(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
