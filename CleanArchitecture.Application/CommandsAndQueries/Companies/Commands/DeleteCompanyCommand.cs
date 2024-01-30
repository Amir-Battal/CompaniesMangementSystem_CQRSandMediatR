using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;

public class DeleteCompanyCommand : IRequest<Company>
{
    public int Id { get; set; }
}
