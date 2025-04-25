using FluentValidation.AspNetCore;
using GoldCS.API.Configurations;
using src.Extensions;
using src.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddControllers()
	.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(typeof(Program).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddHostedServices(); 
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await DataExtension.ManageDataAsync(scope.ServiceProvider);
}

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
