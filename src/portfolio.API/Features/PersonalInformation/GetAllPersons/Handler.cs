// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using portfolio.API.Database;
// using portfolio.API.Entities.PersonalInfo;

// namespace portfolio.API.Features.PersonalInformation.GetAllPersons;

// internal sealed class Handler : IRequestHandler<Query, List<Person>>
// {
//     private readonly PortfolioDbContext _dbContext;
//     public Handler(PortfolioDbContext dbContext) => _dbContext = dbContext;
//     public async Task<List<Person>> Handle(Query request, CancellationToken cancellationToken)
//         => await _dbContext.Users.ToListAsync(cancellationToken: cancellationToken);
// }

