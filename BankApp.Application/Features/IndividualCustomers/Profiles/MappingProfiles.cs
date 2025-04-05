using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Commands;
using BankApp.Application.Features.IndividualCustomers.Queries;
using BankApp.Domain.Entities;


namespace BankApp.Application.Features.IndividualCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Request DTOs mappings
            CreateMap<CreateIndividualCustomerRequestDto, IndividualCustomer>();
            CreateMap<UpdateIndividualCustomerRequestDto, IndividualCustomer>();
            CreateMap<DeleteIndividualCustomerRequestDto, IndividualCustomer>();
            CreateMap<GetIndividualCustomerRequestDto, IndividualCustomer>();

            // Response DTOs mappings
            CreateMap<IndividualCustomer, CreateIndividualCustomerResponseDto>();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerResponseDto>();
            CreateMap<IndividualCustomer, DeleteIndividualCustomerResponseDto>();
            CreateMap<IndividualCustomer, GetIndividualCustomerResponseDto>();
        }
    }
} 