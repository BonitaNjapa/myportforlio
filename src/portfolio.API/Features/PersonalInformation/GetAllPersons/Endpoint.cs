using MediatR;
using Carter;

namespace portfolio.API.Features.PersonalInformation.GetAllPersons;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/person", async (ISender sender) =>
       {
           var people = await sender.Send(new Query());
           return Results.Ok(people);
       });
    }
}
