using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerResponse>
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
    public string RegistrationNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}

public class CreateCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
    public string RegistrationNumber { get; set; }
    public string Message { get; set; }
} 