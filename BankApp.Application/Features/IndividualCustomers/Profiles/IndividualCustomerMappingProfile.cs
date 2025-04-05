using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Queries.GetIndividualCustomer;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Profiles;

public class IndividualCustomerMappingProfile : Profile
{
    public IndividualCustomerMappingProfile()
    {
        CreateMap<IndividualCustomer, CreateIndividualCustomerResponse>();
        CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>();
        
        CreateMap<IndividualCustomer, GetIndividualCustomerResponse>();
    }
} 