using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomer;

public class GetCorporateCustomerQuery : IRequest<GetCorporateCustomerResponse>
{
    public Guid Id { get; set; }
}

public class GetCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
    public string RegistrationNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
} 