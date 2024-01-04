using Backend.Application.Extensions;
using Backend.Infrastructure.Extensions;
using Backend.Persistence.Extensions;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using React.AspNet;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServiceRegistration();
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddInfrastructureServiceRegistration(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllAllow");

app.MapControllers();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "wwwroot"; // указываем путь к папке с клиентским приложением
    if (app.Environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer("start");
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
