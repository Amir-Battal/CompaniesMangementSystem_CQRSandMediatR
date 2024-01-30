using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;

public class UpdateCompanyCommand : IRequest<Company>
{
    public int Id { get; set; }
    public AddCompanyDto CompanyDto { get; set;}
}
