using MediatR;
using portfolio.API.Database;
using portfolio.API.Entities.User;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;


internal sealed class Handler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly PortfolioDbContext _dbContext;
    public Handler(PortfolioDbContext dbContext) => _dbContext = dbContext;
    public async Task<Guid> Handle(CreateUserCommand req, CancellationToken cancellationToken)
    {
        var person = new User()
        {
            Username = req.Username,
            FirstName = req.FirstName,
            LastName = req.LastName,
            MiddleName = req.MiddleName,
            Email = req.Email
        };

        await _dbContext.AddAsync(person, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return person.Id;
    }



}