using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<ISearchService, ECommerce.Api.Search.Services.SearchService>();

builder.Services.AddHttpClient("ProductsService", config =>
{
    //config.BaseAddress = new Uri(Configuration["Services:Products"]);
    config.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ProductsUrl"));

});
builder.Services.AddHttpClient("OrdersService", config =>
{
    //config.BaseAddress = new Uri(Configuration["Services:Orders"]);
    config.BaseAddress = new Uri(builder.Configuration.GetValue<string>("OrdersUrl"));
});
builder.Services.AddHttpClient("CustomersService", config =>
{
    // config.BaseAddress = new Uri(Configuration["Services:Customers"]);
    config.BaseAddress = new Uri(builder.Configuration.GetValue<string>("CustomersUrl"));
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
