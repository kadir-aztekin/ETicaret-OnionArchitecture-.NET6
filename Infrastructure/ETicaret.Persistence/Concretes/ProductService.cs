using ETicaret.Application.Abstactions;
using ETicaret.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        => new()
        {
            new Product()
            {
                Id=Guid.NewGuid(), Name="Product",Price=100,Stock=10
            },
            new Product()
            {
                Id=Guid.NewGuid(), Name="Product2",Price=200,Stock=10
            },
            new Product()
            {
                Id=Guid.NewGuid(), Name="Product3",Price=300,Stock=10
            },
            new Product()
            {
                Id=Guid.NewGuid(), Name="Product4",Price=400,Stock=10
            }
        };
    }
}
