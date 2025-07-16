using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderShippingSystem.Infrastructure.Persistence;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using OrderShippingSystem.Application.Features.Products.Handlers;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<OrderShippingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsHandler).Assembly);
});
//DEPENDENCY ?NJECT?ON



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();