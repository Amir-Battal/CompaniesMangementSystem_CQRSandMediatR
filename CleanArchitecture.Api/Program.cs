using CleanArchitecture.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Implementation;
using System.Reflection;
using CleanArchitecture.Application.CommandsAndQueries.Companies.Queries;
using CleanArchitecture.Application.Dtos.Companies;
using CleanArchitecture.Application.CommandsAndQueries.Companies.Handlers;
using CleanArchitecture.Application.CommandsAndQueries.Companies.Commands;
using CleanArchitecture.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProduceService, ProduceService>();
builder.Services.AddScoped<ISupplyService, SupplyService>();
builder.Services.AddScoped<IReportService, ReportService>();

//builder.Services.AddMediatR(typeof(StartupBase));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddTransient<IRequestHandler<GetAllCompaniesQuery, IEnumerable<GetCompanyDto>>, GetAllCompaniesQueryHandler>();
builder.Services.AddTransient<IRequestHandler<AddCompanyCommand, Company>, AddCompanyCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateCompanyCommand, Company>, UpdateCompanyCommandHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteCompanyCommand, Company>, DeleteCompanyCommandHandler>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
