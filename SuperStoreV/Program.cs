using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperStoreV.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SuperStoreVContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperStoreVContext") ?? throw new InvalidOperationException("Connection string 'SuperStoreVContext' not found.")));

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();


//take the opportunity for add the data to the database
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<SuperStoreVContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
    {
    context.Database.Migrate();
    DbInitializer.Initialize(context);
    }
catch (Exception ex)
    {

    logger.LogError(ex, "An error occurred while migrating the database.");
    }

app.Run();
