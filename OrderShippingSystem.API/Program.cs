using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderShippingSystem.Infrastructure.Persistence;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Infrastructure.Repositories;
using OrderShippingSystem.Application.Features.Products.Handlers;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Strategies;
using Serilog;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OrderShippingSystem.Application.Validators;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssembly(typeof(CreateProductDtoValidator).Assembly);
    });
//product için yaptýklarým aþaðýda
//builder.Services.AddControllers()
  //  .AddFluentValidation(fv =>
    //{
      //  fv.RegisterValidatorsFromAssembly(typeof(CreateProductDtoValidator).Assembly);
    //});


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderShippingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<ICargoStrategyFactory, CargoStrategyFactory>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsHandler).Assembly);
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


try
{
    Log.Information("Uygulama baþlatýlýyor...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Uygulama baþlatýlýrken hata oluþtu!");
}
finally
{
    Log.Information("Uygulama kapanýyor.");
    Log.CloseAndFlush();
}
