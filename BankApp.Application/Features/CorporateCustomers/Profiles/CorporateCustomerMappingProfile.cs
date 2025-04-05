using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;
using BankApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomer;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCustomers.Profiles;

public class CorporateCustomerMappingProfile : Profile
{
    public CorporateCustomerMappingProfile()
    {
        CreateMap<CorporateCustomer, CreateCorporateCustomerResponse>();
        CreateMap<CreateCorporateCustomerCommand, CorporateCustomer>();
        
        CreateMap<CorporateCustomer, GetCorporateCustomerResponse>();
    }
} 