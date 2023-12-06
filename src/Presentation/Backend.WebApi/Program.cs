using Backend.Application.Extensions;
using Backend.Infrastructure.Extensions;
using Backend.Persistence.Context;
using Backend.Persistence.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Views/public" });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServiceRegistration();
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddInfrastructureServiceRegistration();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllAllow");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();
app.UseDefaultFiles();

app.Run();
