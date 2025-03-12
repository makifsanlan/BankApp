using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;

namespace BankApp.Persistence.Repositories;

public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, Guid, BankAppDbContext>, IIndividualCustomerRepository
{
    public IndividualCustomerRepository(BankAppDbContext context) : base(context)
    {
    }
} 