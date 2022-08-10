using ETicaret.Application.Abstactions;
using ETicaret.Persistence.Concretes;
using ETicaret.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddSingleton<IProductService, ProductService>();
            service.AddDbContext<ETicaretDbContext>(options => options.UseNpgsql(
                "User ID=root;Password=1234;Host=localhost;Port=5432;Database=ETicaret;"));
        }
    }
}
