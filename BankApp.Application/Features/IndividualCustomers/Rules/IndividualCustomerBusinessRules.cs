using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Core.CrossCuttingConcerns.Exceptions;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task CustomerShouldNotExistWithSameNationalId(string nationalId)
    {
        var customer = await _individualCustomerRepository.GetByNationalIdAsync(nationalId);
        if (customer != null)
            throw new BusinessException(IndividualCustomerMessages.CustomerAlreadyExists);
    }

    public void CheckNationalIdValidity(string nationalId)
    {
        if (string.IsNullOrEmpty(nationalId) || nationalId.Length != 11 || !nationalId.All(char.IsDigit))
            throw new BusinessException(IndividualCustomerMessages.InvalidNationalId);
    }

    public async Task CustomerShouldExist(Guid id)
    {
        var customer = await _individualCustomerRepository.GetByIdAsync(id);
        if (customer == null)
            throw new BusinessException(IndividualCustomerMessages.CustomerNotFound);
    }

    public void CheckCustomerAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateOfBirth.Year;
        
        if (dateOfBirth.Date > today.AddYears(-age))
            age--;

        if (age < 18)
            throw new BusinessException("Müşteri 18 yaşından büyük olmalıdır.");
    }

    public async Task NationalIdCannotBeDuplicatedWhenInserted(string nationalId)
    {
        IndividualCustomer? result = await _individualCustomerRepository.GetAsync(i => i.NationalId == nationalId);
        if (result != null)
            throw new BusinessException(IndividualCustomerMessages.NationalIdExists);
    }

    public Task IndividualCustomerShouldExistWhenSelected(IndividualCustomer? individualCustomer)
    {
        if (individualCustomer == null)
            throw new BusinessException(IndividualCustomerMessages.NotFound);
        return Task.CompletedTask;
    }
} 