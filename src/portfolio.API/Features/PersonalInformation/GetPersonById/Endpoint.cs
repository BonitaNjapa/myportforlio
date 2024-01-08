using Carter;
using MediatR;

namespace portfolio.API.Features.PersonalInformation.GetPersonById
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/person/{id}", async (int id, ISender sender) =>
            {
                try
                {
                    var person = await sender.Send(new GetPersonByIdQuery(id));
                    return Results.Ok(person);
                }
                catch (Exception ex)
                {
                    return Results.NotFound();
                }

            });
        }
    }
}