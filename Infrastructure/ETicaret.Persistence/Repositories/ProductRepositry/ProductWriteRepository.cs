using ETicaret.Application.Repositories.IProductRepository;
using ETicaret.Domain.Entites;
using ETicaret.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repositories.ProductRepositry
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretDbContext eticaretDbContext) : base(eticaretDbContext)
        {
        }
    }
}
