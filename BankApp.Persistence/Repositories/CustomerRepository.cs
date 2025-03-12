using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;

namespace BankApp.Persistence.Repositories;

public class CustomerRepository : EfRepositoryBase<Customer, Guid, BankAppDbContext>, ICustomerRepository
{
    public CustomerRepository(BankAppDbContext context) : base(context)
    {
    }
} 