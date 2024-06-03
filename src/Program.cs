using Microsoft.EntityFrameworkCore;
using Real_state_Backend.src.Shared.Persistence;
using Real_state_Backend.src.User.Infraestructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("DB"));

builder.Services.AddUserServices();

builder.Services.AddCors(options =>
    options.AddPolicy(name: "corspolicy",
                      policy => policy.WithOrigins("*")));


var app = builder.Build();

app.MapGet("/health", () => new { status = "Server live  🚀" });



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


