using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WayToHair.Core.Repositories;
using WayToHair.Core.Services;
using WayToHair.Core.UnitOfWorks;
using WayToHair.Repository;
using WayToHair.Repository.GenericRepository;
using WayToHair.Repository.Repositories;
using WayToHair.Repository.UnitOfWorks;
using WayToHair.Service.Mapping;
using WayToHair.Service.Services;
using WayToHair.Service.Validations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddFluentValidation(x=> x.RegisterValidatorsFromAssemblyContaining<ContactDtoValidator>());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ConctactService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContext<AppDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(builder.Configuration.GetConnectionString("SqlConnection"), serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());



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
