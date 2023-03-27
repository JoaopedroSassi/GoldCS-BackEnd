using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Middlewares;
using src.Repositories;
using src.Repositories.Interfaces;
using src.Services;
using src.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(typeof(Program).Assembly));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GoldCSDBContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLServer"),
	assembly => assembly.MigrationsAssembly(typeof(GoldCSDBContext).Assembly.FullName));
});

//Dependency injections
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();



builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
