using MediatR;
using static BankApp.Application.Features.CorporateCustomers.Queries.GetList.GetListCorporateCustomerQuery;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetList;

public class GetListCorporateCustomerQuery : IRequest<List<GetListCorporateCustomerResponse>>
{
    public class GetListCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
} 