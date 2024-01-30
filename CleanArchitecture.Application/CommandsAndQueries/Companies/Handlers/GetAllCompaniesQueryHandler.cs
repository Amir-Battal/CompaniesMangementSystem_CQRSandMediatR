using CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;
using CleanArchitecture.Application.CommandsAndQueries.Companies.Queries;
using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Handlers;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<GetCompanyDto>>
{
    private readonly ICompanyService _companyService;

    public GetAllCompaniesQueryHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<IEnumerable<GetCompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyService.GetAll();
        var companyDtos = new List<GetCompanyDto>();

        foreach (var company in companies)
        {
            companyDtos.Add(new GetCompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Location = company.Location,
                EstDate = company.EstDate,
                IsActive = company.IsActive,
            });
        }

        return companyDtos;
    }


}
