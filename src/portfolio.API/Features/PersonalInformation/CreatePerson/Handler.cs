using MediatR;
using portfolio.API.Database;
using portfolio.API.Entities.PersonalInfo;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;


internal sealed class Handler : IRequestHandler<CreateUserCommand, int>
{
    private readonly PortfolioDbContext _dbContext;
    public Handler(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> Handle(CreateUserCommand req, CancellationToken cancellationToken)
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