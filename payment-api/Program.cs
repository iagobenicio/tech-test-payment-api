using System.Text.Json.Serialization;
using payment_api.Models;
using payment_api.repositories;

var builder = WebApplication.CreateBuilder(args);

List<Sale> sale = new List<Sale>();
// Add services to the container.
builder.Services.AddSingleton<ISalesRepository>(new SaleRepositoryDataLocal(sale));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    
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
