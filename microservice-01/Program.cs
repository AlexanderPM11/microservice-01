using microservice_01.Modules.Swagger;
using microservice_01.Repositories;
using microservice_01.Settings;
using microservice_01.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// =========================================================================
// OPCIÓN 1: Persistencia con MongoDB
// =========================================================================
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    return new MongoClient(mongoDbSettings?.ConnectionString);
});

builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepository>();

// =========================================================================
// OPCIÓN 2: Persistencia SQL (usando EF Core y Base de Datos en Memoria)
// Para usar esta opción, comenta la Opción 1 y descomenta las siguientes líneas:
// =========================================================================
// builder.Services.AddDbContext<CatalogDbContext>(options =>
//     options.UseInMemoryDatabase("CatalogDb"));
// builder.Services.AddScoped<IItemsRepository, SqlItemsRepository>();
// =========================================================================

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwagger(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Modified V.2");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
