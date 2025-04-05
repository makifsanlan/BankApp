using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;


namespace BankApp.Application.Features.IndividualCustomers.Commands.Create
{
    public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponseDto>
    {
        public CreateIndividualCustomerRequestDto RequestDto { get; set; }

        public CreateIndividualCustomerCommand(CreateIndividualCustomerRequestDto requestDto)
        {
            RequestDto = requestDto;
        }
    }

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules businessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerResponseDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(request.RequestDto.NationalId);

            IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(request.RequestDto);
            IndividualCustomer createdIndividualCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);
            CreateIndividualCustomerResponseDto response = _mapper.Map<CreateIndividualCustomerResponseDto>(createdIndividualCustomer);
            
            return response;
        }
    }
} 