using AutoMapper;
using FluentValidation;
using MediatR;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Domain.Entities;
using BankApp.Application.Services.Repositories;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MotherName { get; set; }
    public string FatherName { get; set; }
    public string NationalId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldNotExistWithSameNationalId(request.NationalId);

            var individualCustomer = _mapper.Map<IndividualCustomer>(request);
            await _individualCustomerRepository.AddAsync(individualCustomer);

            var response = _mapper.Map<CreateIndividualCustomerResponse>(individualCustomer);
            response.Message = IndividualCustomerMessages.Created;

            return response;
        }
    }

    public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
    {
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandValidator(IndividualCustomerBusinessRules businessRules)
        {
            _businessRules = businessRules;

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Ad alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Ad alanı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter olmalıdır.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Soyad alanı boş geçilemez.")
                .MinimumLength(2).WithMessage("Soyad alanı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Soyad alanı en fazla 50 karakter olmalıdır.");

            RuleFor(c => c.MotherName)
                .NotEmpty().WithMessage("Anne adı boş geçilemez.")
                .MinimumLength(2).WithMessage("Anne adı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Anne adı en fazla 50 karakter olmalıdır.");

            RuleFor(c => c.FatherName)
                .NotEmpty().WithMessage("Baba adı boş geçilemez.")
                .MinimumLength(2).WithMessage("Baba adı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Baba adı en fazla 50 karakter olmalıdır.");

            RuleFor(c => c.NationalId)
                .NotEmpty().WithMessage("TC Kimlik numarası boş geçilemez.")
                .Must((command, nationalId) => 
                {
                    _businessRules.CheckNationalIdValidity(nationalId);
                    return true;
                });

            RuleFor(c => c.DateOfBirth)
                .NotEmpty().WithMessage("Doğum tarihi boş geçilemez.")
                .Must((command, dateOfBirth) => 
                {
                    _businessRules.CheckCustomerAge(dateOfBirth);
                    return true;
                });

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-posta adresi boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez.")
                .Matches(@"^(\+90|0)?[0-9]{10}$").WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Adres alanı boş geçilemez.")
                .MinimumLength(10).WithMessage("Adres alanı en az 10 karakter olmalıdır.")
                .MaximumLength(200).WithMessage("Adres alanı en fazla 200 karakter olmalıdır.");
        }
    }
}

public class CreateIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public string Message { get; set; }
} 