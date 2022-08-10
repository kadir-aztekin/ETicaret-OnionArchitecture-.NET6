using ETicaret.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.Abstactions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
