using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddScoped<AdvWorksApiDefaults, AdvWorksApiDefaults>();
builder.Services.AddSingleton<AdvWorksApiDefaults, AdvWorksApiDefaults>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

//Configure Logging to Console

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console();

    //Logging to Rolling File
    lc.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



//Enable Exception Handling Middleware
app.UseExceptionHandler("/ProductionError");



app.UseAuthorization();

app.MapControllers();

app.Run();
