using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portfolio.API.Database;
using portfolio.API.Entities.PersonalInfo;

namespace portfolio.API.Features.PersonalInformation;

public static class GetAllQuery
{
    public sealed class Query : IRequest<List<Person>>
    {
    }
    internal sealed class QueryHandler : IRequestHandler<Query, List<Person>>
    {
        private readonly PortfolioDbContext _dbContext;
        public QueryHandler(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Person>> Handle(Query request, CancellationToken cancellationToken)
            => await _dbContext.PersonalInfos.ToListAsync(cancellationToken: cancellationToken);
    }

    public static void AddQueryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/person", async (ISender sender) =>
        {
            var books = await sender.Send(new());
            return Results.Ok(books);
        });
    }
}