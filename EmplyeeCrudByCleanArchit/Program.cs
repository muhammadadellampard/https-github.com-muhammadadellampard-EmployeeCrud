
using EmployeeCrud.Core.AppSettings;
using EmployeeCrud.Core.Services;
using EmplyeeCrud.Infrastructure;
using EmplyeeCrud.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
//config appsettings
//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
//builder.Services.Configure<JWT>(builder.Configuration.GetSection("Jwt"));

// Add services to the container.
builder.Services.AddInfrastructureDIServices(builder.Configuration);
builder.Services.AddServicesDIServices(builder.Configuration);
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

app.UseHttpsRedirection();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
