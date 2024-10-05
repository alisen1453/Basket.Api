using Basket.Api.Access.Context;
using Basket.Api.Access.Repository;
using Basket.Api.Bussiness.Abstract;
using Basket.Api.Bussiness.Services;
using Basket.Api.Core.Abstract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BasketDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectString"),
        b => b.MigrationsAssembly("Basket.Api.Services")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Ýnterface AddScoppe
builder.Services.AddScoped(typeof(IRepository<>),typeof(BasketRepository<>));
builder.Services.AddScoped<IBasketCartServices,BasketCartServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
//builder.Services.AddScoped<IBasketItemServices, BasketItemServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();

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
