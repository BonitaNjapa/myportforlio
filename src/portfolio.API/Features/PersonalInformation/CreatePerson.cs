using MediatR;
using portfolio.API.Database;
using portfolio.API.Entities.PersonalInfo;

namespace portfolio.API.Features.PersonalInformation;

public class CreatePersonRequest : IRequest<int>
{
    public required string first_name { get; set; }
    public required string last_name { get; set; }
    public required string date_of_birth { get; set; }
    public required string gender { get; set; }
    public required string ethnicity { get; set; }
}

public static class CreatePerson
{
    public sealed class CreatePersonCommand : IRequest<int>
    {
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string date_of_birth { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string ethnicity { get; set; } = string.Empty;
    }
    internal sealed class Handler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly PortfolioDbContext _dbContext;
        public Handler(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreatePersonCommand req, CancellationToken cancellationToken)
        {
            var person = new Person()
            {
                first_name = req.first_name,
                last_name = req.last_name,
                date_of_birth = req.date_of_birth,
                gender = req.gender,
                ethnicity = req.ethnicity
            };
            await _dbContext.AddAsync(person, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return person.personal_info_id;
        }


    }
    public static void AddEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/person", async (CreatePersonRequest request, ISender sender) =>
        {
            // var personId = await sender.Send(request);
            var personId = await sender.Send(new CreatePersonCommand
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