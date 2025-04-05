using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommand : IRequest<DeleteCorporateCustomerResponse>
{
    public Guid Id { get; set; }
}

public class DeleteCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; }
} 