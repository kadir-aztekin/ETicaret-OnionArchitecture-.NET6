using ETicaret.Application.Valdations.Products;
using ETicaret.Infrastructure.Filters;
using ETicaret.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//VALÝDATON
builder.Services.AddControllers(options=>options.Filters.Add<ValidatonFilter>())
    .AddFluentValidation(configuration => configuration.
RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions
(options=>options.SuppressModelStateInvalidFilter=true);

builder.Services.AddPersistenceServices();
builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins
("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
