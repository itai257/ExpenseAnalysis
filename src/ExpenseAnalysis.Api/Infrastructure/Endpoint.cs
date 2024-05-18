using MediatR;

namespace ExpenseAnalysis.Api.Infrastructure;

public abstract class Endpoint<TReq, TRes> where TReq : IRequest<TRes>
{
    public abstract void MapEndpoint(IEndpointRouteBuilder builder);

    public async Task<TRes> Handle(ISender sender, [AsParameters] TReq request)
    {
        return await sender.Send(request);
    }
}

public abstract class Endpoint<T> where T : IRequest
{
    public abstract void MapEndpoint(IEndpointRouteBuilder builder);

    public async Task Handle(ISender sender, [AsParameters] T request)
    {
        await sender.Send(request);
    }
}