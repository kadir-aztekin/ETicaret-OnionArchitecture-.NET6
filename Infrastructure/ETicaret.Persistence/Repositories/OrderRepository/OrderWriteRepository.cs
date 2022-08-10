using ETicaret.Application.Repositories.IOrderRepository;
using ETicaret.Domain.Entites;
using ETicaret.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repositories.OrderRepository
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETicaretDbContext eticaretDbContext) : base(eticaretDbContext)
        {
        }
    }
}
