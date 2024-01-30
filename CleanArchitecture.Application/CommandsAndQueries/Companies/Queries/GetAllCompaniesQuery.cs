using CleanArchitecture.Application.Dtos.Companies;
using MediatR;

namespace CleanArchitecture.Application.CommandsAndQueries.Companies.Queries;

public class GetAllCompaniesQuery : IRequest<IEnumerable<GetCompanyDto>>
{

}
