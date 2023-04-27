using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository;
using PerfumeApiBackend.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string CONNECTIONNAME = "PerfumeDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
builder.Services.AddDbContext<PerfumeContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<PerfumeRepository>();
builder.Services.AddScoped<PerfumeryRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region Migrations
/*
using(var scope = app.Services.CreateScope())
{
    PerfumeContext context = scope.ServiceProvider.GetRequiredService<PerfumeContext>();
    context.Database.Migrate();
}
*/
#endregion


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
