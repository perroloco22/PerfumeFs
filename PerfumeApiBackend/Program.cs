using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NuGet.Protocol.Core.Types;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Extension;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository;
using PerfumeApiBackend.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//--Add DbContext with appsettings.json
//const string CONNECTIONNAME = "PerfumeDB";
//var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//--Add DbContext with secret manager
const string CONNECTIONNAME = "PerfumeProject:ConnectionStrings";
string connectionString = builder.Configuration.GetValue<string>(CONNECTIONNAME);

builder.Services.AddDbContext<PerfumeContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<PerfumeRepository>();
builder.Services.AddScoped<PerfumeryRepository>();

//Add Jwt Services
builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization using Bearer Schemes"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id= "Bearer"
                }
            },
            new string[]{}

        }

    });


});


//CORS Configuration 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//Tell app to user CORS
app.UseCors("Cors Policy");


app.Run();
