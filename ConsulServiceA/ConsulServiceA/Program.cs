using Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new
ConsulClient(consulConfig =>
{
    consulConfig.Address = new Uri("http://localhost:8500");
}));

builder.Services.AddControllers();
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
