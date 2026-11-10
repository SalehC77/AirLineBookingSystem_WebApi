using AirLineBookingSystem_WebApi.Data;
using AirLineBookingSystem_WebApi.Controllers.TicketBooking;
using AirLineBookingSystem_WebApi.Controllers.Ticket;
using AirLineBookingSystem_WebApi.Controllers.User;
using AirLineBookingSystem_WebApi.Controllers.Passenger;
using AirLineBookingSystem_WebApi.Controllers.Flights;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Our custom services

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITicketBookingService, TicketBookingService>(); 
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IFlightService, FlightService>();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy_AirLineBookingSystem", policy =>
    {
        policy.AllowAnyHeader().AllowCredentials().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200");
    });
});
// Our custom services
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseCors("CorsPolicy_AirLineBookingSystem");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
