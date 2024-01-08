using Carter;
using MediatR;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;

    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/person", async (CreateRequest request, ISender sender) =>
            {
                var personId = await sender.Send(new CreateCommand
                {
                    first_name = request.first_name,
                    last_name = request.last_name,
                    date_of_birth = request.date_of_birth,
                    gender = request.gender,
                    ethnicity = request.ethnicity
                });
                return Results.Ok(personId);
            });
        }
    }
