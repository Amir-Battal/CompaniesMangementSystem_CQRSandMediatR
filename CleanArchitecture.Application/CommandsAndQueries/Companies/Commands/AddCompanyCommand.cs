using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;

public class AddCompanyCommand : IRequest<Company>
{
    public AddCompanyCommand(AddCompanyDto dto)
    {
        Company = dto;
    }

    public AddCompanyDto Company { get; }
}
