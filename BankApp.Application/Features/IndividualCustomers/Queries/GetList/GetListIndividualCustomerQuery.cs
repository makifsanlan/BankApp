using MediatR;
using static BankApp.Application.Features.IndividualCustomers.Queries.GetList.GetListIndividualCustomerQuery;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQuery : IRequest<List<GetListIndividualCustomerResponse>>
{
    public class GetListIndividualCustomerResponse
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
} 