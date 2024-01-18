using System.Net;
using MediatR;
using portfolio.API.Database;
using portfolio.API.Entities.User;
using portfolio.API.Shared;
using src.Services.Repositories.Auth.RegisterRepository;

namespace portfolio.API.Features.Auth.Register;


internal sealed class Handler : IRequestHandler<RegisterUserCommand, string> 
{
    private readonly PortfolioDbContext _dbContext;
    private IRegisterRepository _registerService;

    public Handler(PortfolioDbContext dbContext, IRegisterRepository registerRepository)
    {
        _dbContext = dbContext;
        _registerService = registerRepository;
    }
    public async Task<string> Handle(RegisterUserCommand req, CancellationToken cancellationToken)
    {

        if (await _registerService.UserExists(req.Email))   
            return "Duplicate Email";

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