using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Repositories;
using src.Repositories.Interfaces;
using src.Services;
using src.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
