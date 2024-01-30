namespace CleanArchitecture.Application.Dtos.Companies;

public class GetCompanyDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public DateTime EstDate { get; set; }

    public bool IsActive { get; set; }
}
