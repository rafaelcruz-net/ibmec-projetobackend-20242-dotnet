using Microsoft.EntityFrameworkCore;
using SampleWebApi.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
                //.AddJsonOptions(c =>
                //{
                //    c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                //    c.JsonSerializerOptions.MaxDepth = 0;
                //});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SampleContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("postgre"));
});

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
