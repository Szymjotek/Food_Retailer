using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SaleKiosk.Application.Mappings;
using SaleKiosk.Application.Services;
using SaleKiosk.Application.Validators;
using SaleKiosk.BlazorServer.Data;
using SaleKiosk.Domain.Contracts;
using SaleKiosk.Infrastructure;
using SaleKiosk.Infrastructure.Repositories;
using SaleKiosk.SharedKernel.Dto;
using NLog.Web;
using NLog;
using SaleKiosk.BlazorServer.Services;
using Radzen;


// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddSingleton<WeatherForecastService>();

    // rejestracja automappera w kontenerze IoC
    builder.Services.AddAutoMapper(typeof(FoodWarehouseMappingProfile));

    // rejestracja kontekstu bazy w kontenerze IoC
    // var sqliteConnectionString = "Data Source=Kiosk.WebAPI.Logger.db";
    var sqliteConnectionString = @"Data Source=E:\coding\pab\dbs\Food_Retailer.db";
    builder.Services.AddDbContext<FoodWarehouseDbContext>(options =>
        options.UseSqlite(sqliteConnectionString));

    // rejestracja walidatora
    builder.Services.AddScoped<IValidator<CreateProductDto>, RegisterCreateProductDtoValidator>();
    builder.Services.AddScoped<IValidator<UpdateProductDto>, RegisterUpdateProductDtoValidator>();

    builder.Services.AddScoped<IValidator<CreateCustomerDto>, RegisterCustomerDtoValidator>();
    builder.Services.AddScoped<IValidator<UpdateCustomerDto>, RegisterUpdateCustomerDtoValidator>();

    builder.Services.AddScoped<IValidator<CreateSupplierDto>, RegisterCreateSupplierDtoValidator>();
    builder.Services.AddScoped<IValidator<UpdateSupplierDto>, RegisterUpdateSupplierDtoValidator>();


    builder.Services.AddScoped<IFoodWarehouseUnitOfWork, FoodWarehouseUnitOfWork>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<DataSeeder>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IFileService, FileService>();

    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IOrderService, OrderService>();

    builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
    builder.Services.AddScoped<ICustomerService, CustomerService>();

    builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
    builder.Services.AddScoped<ISupplierService, SupplierService>();


    builder.Services.AddRadzenComponents();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler(" / Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    //// seeding data
    //using (var scope = app.Services.CreateScope())
    //{
    //    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    //    dataSeeder.Seed();
    //}

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

