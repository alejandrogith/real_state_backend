using Microsoft.EntityFrameworkCore;
using real_state_backend.src.Shared.Application;
using real_state_backend.src.Shared.Infraestructure.Bus.Command;
using real_state_backend.src.Shared.Infraestructure.Bus.Query;
using Real_state_Backend.src.Users.Infraestructure;
using Serilog;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using real_state_backend.src.Shared.Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
var logger = new LoggerConfiguration()

    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Services.AddSerilog(logger);
*/
builder.Services.AddQueryServices();
builder.Services.AddCommandServices();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("DB"));

builder.Services.AddUserServices();


builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddCors(options =>
    options.AddPolicy(name: "corspolicy",
                      policy => policy.WithOrigins("*")));


var app = builder.Build();

app.MapGet("/health", () => new { status = "Server live  🚀" });

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("corspolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();


