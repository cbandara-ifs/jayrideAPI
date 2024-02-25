using Jayride.Api.DataAccess;
using Jayride.Api.DataAccess.Repositories;
using Jayride.Api.DataAccess.Repositories.Interfaces;
using Jayride.Api.Services;
using Jayride.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();


builder.Services.AddDbContext<ApiDbContext>(dbContextOptions =>
        dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]));

builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();

builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IVehicleServices, VehicleServices>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
