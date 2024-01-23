using MediatR;
using portfolio.API.Database;
using portfolio.API.Entities.User;

namespace portfolio.API.Features.Auth.Register;


internal sealed class Handler : IRequestHandler<RegisterUserCommand, string> 
{
    private readonly PortfolioDbContext _dbContext;

    public Handler(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> Handle(RegisterUserCommand req, CancellationToken cancellationToken)
    {

        
        var person = new User()
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            MiddleName = req.MiddleName,
            Email = req.Email
        };



        await _dbContext.AddAsync(person, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return "User created successfully";
    }



}