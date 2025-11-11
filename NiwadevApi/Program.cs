using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NiwadevApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NiwadevApiContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("NiwadevApiContext") ?? throw new InvalidOperationException("Connection string 'NiwadevApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//sbuilder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}
 app.UseSwagger();
    app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.MapGet("/", () => "Hello, World!");
app.Run();
