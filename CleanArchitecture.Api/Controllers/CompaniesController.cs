using CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;
using CleanArchitecture.Application.CommandsAndQueries.Companies.Queries;
using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var query = new GetAllCompaniesQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm] AddCompanyDto dto)
    {
        var command = new AddCompanyCommand(dto);
        var result = await _mediator.Send(command);

        return Ok(result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] AddCompanyDto dto)
    {
        var command = new UpdateCompanyCommand
        {
            Id = id,
            CompanyDto = dto
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var command = new DeleteCompanyCommand { Id = id };
        var result = await _mediator.Send(command);

        return Ok(result);
    }

}
