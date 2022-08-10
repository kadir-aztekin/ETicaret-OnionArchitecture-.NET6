using ETicaret.Application.Repositories.ICustomerRepository;
using ETicaret.Domain.Entites;
using ETicaret.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repositories.CustomerRepository
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ETicaretDbContext eTicaretDbContext) : base(eTicaretDbContext)
        {
        }
    }
}
