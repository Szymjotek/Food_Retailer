using Microsoft.EntityFrameworkCore;
using SaleKiosk.Application.Services;
using SaleKiosk.Domain.Contracts;
using SaleKiosk.Infrastructure.Repositories;
using SaleKiosk.Infrastructure;
using SaleKiosk.SharedKernel.Dto;
using SaleKiosk.WebAPI.Middleware;
using SaleKiosk.Application.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using SaleKiosk.Application.Validators;
using NLog.Web;
using NLog;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // rejestracja automappera w kontenerze IoC
    builder.Services.AddAutoMapper(typeof(KioskMappingProfile));

    // rejestracja automatycznej walidacji (FluentValidation waliduje i przekazuje wynik przez ModelState)
    builder.Services.AddFluentValidationAutoValidation();

    // rejestracja kontekstu bazy w kontenerze IoC
    // var sqliteConnectionString = "Data Source=Kiosk.WebAPI.Logger.db";
    var sqliteConnectionString = @"Data Source=C:\Users\szymo\Downloads\Projekt\SaleKiosk_Order_CompletedSaleKioskStudent.db";
    builder.Services.AddDbContext<KioskDbContext>(options =>
        options.UseSqlite(sqliteConnectionString));

    // rejestracja walidatora
    builder.Services.AddScoped<IValidator<CreateProductDto>, RegisterCreateProductDtoValidator>();

    builder.Services.AddScoped<IKioskUnitOfWork, KioskUnitOfWork>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<DataSeeder>();
    builder.Services.AddScoped<IProductService, ProductService>();

    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IOrderService, OrderService>();

    builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
    builder.Services.AddScoped<ICustomerService, CustomerService>();

    builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
    builder.Services.AddScoped<ISupplierService, SupplierService>();

    builder.Services.AddScoped<ExceptionMiddleware>();

    // rejestruje w kontenerze zale�no�ci polityk� CORS o nazwie SaleKioks,
    // kt�ra zapewnia dost�p do API z dowolnego miejsca oraz przy pomocy dowolnej metody
    builder.Services.AddCors(o => o.AddPolicy("SaleKiosk", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseStaticFiles();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    // wstawia polityk� CORS obs�ugi do potoku ��dania
    app.UseCors("SaleKiosk");

    // seeding data
    using (var scope = app.Services.CreateScope())
    {
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        dataSeeder.Seed();
    }

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






