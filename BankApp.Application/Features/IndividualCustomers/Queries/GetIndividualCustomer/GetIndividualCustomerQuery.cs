using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetIndividualCustomer;

public class GetIndividualCustomerQuery : IRequest<GetIndividualCustomerResponse>
{
    public Guid Id { get; set; }
}

public class GetIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
} 