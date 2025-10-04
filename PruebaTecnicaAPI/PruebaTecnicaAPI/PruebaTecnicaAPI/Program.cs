using PruebaTecnicaAPI.DataAccess.Interface;
using PruebaTecnicaAPI.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<PruebaTecnicaAPI.BusinessLogic.Interface.IEmpleado, PruebaTecnicaAPI.BusinessLogic.Empleado>();
builder.Services.AddScoped<IConnectionManagerDbContext, ConnectionManagerDbContext>();
builder.Services.AddScoped<PruebaTecnicaAPI.DataAccess.Interface.IEmpleado, PruebaTecnicaAPI.DataAccess.Empleado>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConnectionManagerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
