using CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Handlers;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Company>
{
    private readonly ICompanyService _companyService;

    public UpdateCompanyCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyService.GetById(request.Id);

        company.Name = request.CompanyDto.Name;
        company.Location = request.CompanyDto.Location;
        company.EstDate = request.CompanyDto.EstDate;
        company.IsActive = request.CompanyDto.IsActive;

        await _companyService.Update(company);


        return company;
    }
}
