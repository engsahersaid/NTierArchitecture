using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.BLL.Services;
using NTierArchitecture.BLL.Services.Interfaces;
using NTierArchitecture.DAL.Data;
using NTierArchitecture.DAL.Repositories;
using NTierArchitecture.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddAutoMapper(typeof(NTierArchitecture.BLL.Mapping.MappingProfile).Assembly);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddValidatorsFromAssembly(typeof(NTierArchitecture.BLL.Validations.EmployeeValidator).Assembly);

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