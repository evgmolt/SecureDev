using VinylCatalogApi.Models;
using VinylCatalogApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<VinylCatalogDatabaseSettings>(
    builder.Configuration.GetSection("VinylCatalogDatabase"));
builder.Services.AddSingleton<VinylsService>();

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
