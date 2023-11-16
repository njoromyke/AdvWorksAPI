using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddScoped<AdvWorksApiDefaults, AdvWorksApiDefaults>();
builder.Services.AddSingleton<AdvWorksApiDefaults, AdvWorksApiDefaults>();
AdvWorksApiDefaults settings = new();
builder.Configuration.GetSection("AdvWorksAPI").Bind(settings);
builder.Services.AddSingleton<AdvWorksApiDefaults>(settings);

builder.Services.Configure<AdvWorksApiDefaults>(builder.Configuration.GetSection("AdvWorksAPI"));

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();


//Configure Logging to Console

builder.Host.UseSerilog(
    (ctx, lc) =>
    {
        lc.WriteTo.Console();

        //Logging to Rolling File
        lc.WriteTo.File(
            "Logs/InfoLog-.txt",
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Information
        );
        lc.WriteTo.File(
            "Logs/ErrorLog-.txt",
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Error
        );
    }
);

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.PropertyNamingPolicy= null);

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

app.UseExceptionHandler(app.Environment.IsDevelopment() ? "/DevelopmentError" : "/ProductionError");

app.UseStatusCodePagesWithReExecute("/StatusCodeHandler/{0}");

app.UseAuthorization();

app.MapControllers();

app.Run();
