// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using portfolio.API.Database;
// using portfolio.API.Entities.PersonalInfo;

// namespace portfolio.API.Features.PersonalInformation.GetPersonById;

// internal sealed class Handler : IRequestHandler<GetPersonByIdQuery, Person?>
// {
//     private readonly PortfolioDbContext _dbContext;
//     public Handler(PortfolioDbContext dbContext) => _dbContext = dbContext;

//     public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
//     {
//        var person = await _dbContext.PersonalInfos
//         .FirstOrDefaultAsync(p => p.personal_info_id.Equals(request.PersonId), cancellationToken: cancellationToken);

//     if (person is null)
//         throw new Exception("GetPersonById.NotFound");
    
//     return person;
//     }
// }

