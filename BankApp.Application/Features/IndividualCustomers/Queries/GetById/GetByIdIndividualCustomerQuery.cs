using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Commands;
using BankApp.Application.Features.IndividualCustomers.Queries;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Services.Repositories;


namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById
{
    public class GetByIdIndividualCustomerQuery : IRequest<GetIndividualCustomerResponseDto>
    {
        public GetIndividualCustomerRequestDto RequestDto { get; set; }

        public GetByIdIndividualCustomerQuery(GetIndividualCustomerRequestDto requestDto)
        {
            RequestDto = requestDto;
        }
    }

    public class GetByIdIndividualCustomerQueryHandler : IRequestHandler<GetByIdIndividualCustomerQuery, GetIndividualCustomerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public GetByIdIndividualCustomerQueryHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules businessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _businessRules = businessRules;
        }

        public async Task<GetIndividualCustomerResponseDto> Handle(GetByIdIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(i => i.Id == request.RequestDto.Id);
            await _businessRules.IndividualCustomerShouldExistWhenSelected(individualCustomer);
            
            GetIndividualCustomerResponseDto response = _mapper.Map<GetIndividualCustomerResponseDto>(individualCustomer);
            return response;
        }
    }
} 