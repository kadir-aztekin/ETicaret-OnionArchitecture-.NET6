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
using Microsoft.Extensions.Configuration;
using ETicaret.Application.Repositories.ICustomerRepository;
using ETicaret.Application.Repositories.IOrderRepository;
using ETicaret.Application.Repositories.IProductRepository;
using ETicaret.Persistence.Repositories.CustomerRepository;
using ETicaret.Persistence.Repositories.OrderRepository;
using ETicaret.Persistence.Repositories.ProductRepositry;

namespace ETicaret.Persistence
{
    public static class ServiceRegistration //VERİTABANINA BAGLANMA YERI
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddSingleton<IProductService, ProductService>();
            service.AddDbContext<ETicaretDbContext>(options => options.UseNpgsql(
                "User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=ETicaretDb;"));

            service.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            service.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            
        }
    }
}
