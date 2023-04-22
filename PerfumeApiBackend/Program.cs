using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.DataAccess;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string CONNECTIONNAME = "PerfumeDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
builder.Services.AddDbContext<PerfumeContext>(options => options.UseSqlServer(connectionString));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
