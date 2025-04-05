using FluentValidation;
using BankApp.Application.Features.CorporateCustomers.Rules;

namespace BankApp.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommandValidator : AbstractValidator<CreateCorporateCustomerCommand>
{
    private readonly CorporateCustomerBusinessRules _businessRules;

    public CreateCorporateCustomerCommandValidator(CorporateCustomerBusinessRules businessRules)
    {
        _businessRules = businessRules;

        RuleFor(c => c.CompanyName)
            .NotEmpty().WithMessage("Şirket adı boş geçilemez.")
            .Must((command, companyName) =>
            {
                _businessRules.CheckCompanyName(companyName);
                return true;
            });

        RuleFor(c => c.TaxNumber)
            .NotEmpty().WithMessage("Vergi numarası boş geçilemez.")
            .Must((command, taxNumber) =>
            {
                _businessRules.CheckTaxNumberValidity(taxNumber);
                return true;
            });

        RuleFor(c => c.RegistrationNumber)
            .NotEmpty().WithMessage("Sicil numarası boş geçilemez.")
            .MinimumLength(5).WithMessage("Sicil numarası en az 5 karakter olmalıdır.")
            .MaximumLength(20).WithMessage("Sicil numarası en fazla 20 karakter olmalıdır.");

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