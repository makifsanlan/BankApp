using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;

namespace BankApp.Persistence.Repositories;

public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, Guid, BankAppDbContext>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BankAppDbContext context) : base(context)
    {
    }
} 