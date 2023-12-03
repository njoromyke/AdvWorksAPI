using AdvWorksAPI.ConstantClasses;
using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.ExtensionClasses;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddScoped<AdvWorksApiDefaults, AdvWorksApiDefaults>();

builder.ConfigureGlobalSettings();

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

   builder.Services.ConfigureCors();

//Configure Logging to Console

builder.Host.ConfigureSeriLog();

builder.Services.AddControllers().ConfigureJsonOptions();
   

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

app.UseCors(AdvWorksAPIConstants.CorsPolicy); 

app.UseAuthorization();

app.MapControllers();

app.Run();
