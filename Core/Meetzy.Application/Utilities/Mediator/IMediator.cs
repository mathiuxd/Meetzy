using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Meetzy.Application.Utilities.Mediator
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
        Task Send(IRequest request);

    }
}
