using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommand : IRequest<DeleteIndividualCustomerResponse>
{
    public Guid Id { get; set; }
}

public class DeleteIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; }
} 