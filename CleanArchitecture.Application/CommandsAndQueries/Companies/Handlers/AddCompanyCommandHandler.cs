using CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Handlers;

public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, Company>
{
    private readonly ICompanyService _companyService;

    public AddCompanyCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<Company> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyService.Add(request.Company);
        return new Company
        {
            Id = company.Id,
            Name = company.Name,
            Location = company.Location,
            EstDate = company.EstDate,
            IsActive = company.IsActive,
        };
    }
}
