using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Domain.Contexts;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext>(cfg =>
{
	cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"), cfg =>
	{
		cfg.MigrationsHistoryTable("MigrationHistory");
	});
});

builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
